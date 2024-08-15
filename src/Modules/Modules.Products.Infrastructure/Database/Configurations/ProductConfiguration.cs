using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Products.Domain.Products;

namespace Modules.Products.Infrastructure.Database.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
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

        builder.HasOne(x => x.ProductSubCategory)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductSubCategoryId)
            .HasConstraintName("FK_ProductSubCategory_Product_ProductSubCategoryId");
    }
}