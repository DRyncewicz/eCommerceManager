using Application.Abstractions.Messaging;
using Infrastructure.Database;
using Modules.Products.Domain.Products;
using System.Reflection;

namespace ArchitectureTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(ProductEntity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(ICommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(DbConnectionFactory).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}