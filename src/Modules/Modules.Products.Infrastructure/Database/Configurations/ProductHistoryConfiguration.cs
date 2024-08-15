using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Products.Domain.Products;

namespace Modules.Products.Infrastructure.Database.Configurations;

internal class ProductHistoryConfiguration : IEntityTypeConfiguration<ProductHistoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductHistoryEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(60);

        builder.OwnsOne(x => x.Price, p =>
        {
            p.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("PriceAmount");

            p.Property(x => x.Currency)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnName("PriceCurrency");
        });

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1500);

        builder.Property(x => x.Brand)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ProductSubCategoryId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.CreateDateTimeUtc)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
            .HasPrecision(7);

        builder.Property(x => x.CreatorUserId)
            .IsRequired()
            .HasMaxLength(450);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductHistories)
            .HasForeignKey(x => x.ProductId)
            .HasConstraintName("FK_Product_ProductHistory_ProductId");
    }
}