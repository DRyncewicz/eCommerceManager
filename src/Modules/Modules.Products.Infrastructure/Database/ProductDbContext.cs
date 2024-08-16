using Application.Abstractions.Data;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Modules.Products.Domain.Categories;
using Modules.Products.Domain.Products;
using Modules.Products.Infrastructure.Database.Seeds;
using System.Data;

namespace Modules.Products.Infrastructure.Database;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<ProductHistoryEntity> ProductHistories { get; set; }

    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

    public DbSet<ProductSubCategoryEntity> ProductSubCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema.Product);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());

        modelBuilder.ProductCategoryDataSeed();
        modelBuilder.ProductSubCategoryDataSeed();
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        return (await Database.BeginTransactionAsync()).GetDbTransaction();
    }
}