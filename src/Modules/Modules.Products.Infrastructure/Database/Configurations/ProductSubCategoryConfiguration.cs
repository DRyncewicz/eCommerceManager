using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Products.Domain.Categories;

namespace Modules.Products.Infrastructure.Database.Configurations;

internal class ProductSubCategoryConfiguration : IEntityTypeConfiguration<ProductSubCategoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductSubCategoryEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.ProductCategoryId)
            .IsRequired();

        builder.HasOne(x => x.ProductCategory)
            .WithMany(x => x.ProductSubCategories)
            .HasForeignKey(x => x.ProductCategoryId)
            .HasConstraintName("FK_ProductSubCategory_ProductCategory_ProductSubCategoryId");
    }
}