using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "pcm",
                table: "product_categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Fashion" },
                    { 3, "House and garden" },
                    { 4, "Automotive" },
                    { 6, "Health and beauty" },
                    { 15, "Collections and art" }
                });

            migrationBuilder.InsertData(
                schema: "pcm",
                table: "product_sub_categories",
                columns: new[] { "id", "name", "product_category_id" },
                values: new object[,]
                {
                    { 1, "Phones and accessories", 1 },
                    { 2, "Laptops and computers", 1 },
                    { 3, "Men's clothing", 2 },
                    { 4, "Women's clothing", 2 },
                    { 5, "Furniture", 3 },
                    { 6, "Garden supplies", 3 },
                    { 7, "Car parts", 4 },
                    { 8, "Automotive accessories", 4 },
                    { 9, "Collectible coins", 15 },
                    { 10, "Art prints", 15 },
                    { 11, "Makeup", 6 },
                    { 12, "Skincare", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_sub_categories",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_categories",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "pcm",
                table: "product_categories",
                keyColumn: "id",
                keyValue: 15);
        }
    }
}
