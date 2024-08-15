using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Modules.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductSchemeInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pcm");

            migrationBuilder.CreateTable(
                name: "outbox_messages",
                schema: "pcm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "jsonb", nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    processed_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_categories",
                schema: "pcm",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_sub_categories",
                schema: "pcm",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    product_category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_sub_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductSubCategory_ProductCategory_ProductSubCategoryId",
                        column: x => x.product_category_id,
                        principalSchema: "pcm",
                        principalTable: "product_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "pcm",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PriceAmount = table.Column<double>(type: "double precision", nullable: false),
                    PriceCurrency = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    product_sub_category_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductSubCategory_Product_ProductSubCategoryId",
                        column: x => x.product_sub_category_id,
                        principalSchema: "pcm",
                        principalTable: "product_sub_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_histories",
                schema: "pcm",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PriceAmount = table.Column<double>(type: "double precision", nullable: false),
                    PriceCurrency = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    weight = table.Column<decimal>(type: "numeric", nullable: false),
                    product_sub_category_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    creator_user_id = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    create_date_time_utc = table.Column<DateTimeOffset>(type: "timestamp(7) with time zone", precision: 7, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_histories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_ProductHistory_ProductId",
                        column: x => x.product_id,
                        principalSchema: "pcm",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_product_histories_product_id",
                schema: "pcm",
                table: "product_histories",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_sub_categories_product_category_id",
                schema: "pcm",
                table: "product_sub_categories",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_product_sub_category_id",
                schema: "pcm",
                table: "products",
                column: "product_sub_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outbox_messages",
                schema: "pcm");

            migrationBuilder.DropTable(
                name: "product_histories",
                schema: "pcm");

            migrationBuilder.DropTable(
                name: "products",
                schema: "pcm");

            migrationBuilder.DropTable(
                name: "product_sub_categories",
                schema: "pcm");

            migrationBuilder.DropTable(
                name: "product_categories",
                schema: "pcm");
        }
    }
}
