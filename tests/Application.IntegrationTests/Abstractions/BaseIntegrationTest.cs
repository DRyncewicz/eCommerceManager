using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Modules.Products.Infrastructure.Database;
using Xunit;

namespace Application.IntegrationTests.Abstractions;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
{
    private readonly IServiceScope _scope;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        ProductDbContext = _scope.ServiceProvider.GetRequiredService<ProductDbContext>();
        Faker = new Faker();
    }

    protected ISender Sender { get; }

    protected ProductDbContext ProductDbContext { get; }

    protected Faker Faker { get; }

    public void Dispose()
    {
        _scope.Dispose();
    }
}