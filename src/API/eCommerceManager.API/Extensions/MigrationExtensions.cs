using Microsoft.EntityFrameworkCore;
using Modules.Products.Infrastructure.Database;

namespace Web.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ProductDbContext productContext =
            scope.ServiceProvider.GetRequiredService<ProductDbContext>();

        productContext.Database.Migrate();
    }
}