using Api.FunctionalTests.Abstractions;
using Api.FunctionalTests.Extensions;
using FluentAssertions;
using Modules.Products.Application.Product;
using Modules.Products.Application.Product.Create;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Api.FunctionalTests.Product;

public class CreateProductTests : BaseFunctionalTest
{
    public CreateProductTests(FunctionalTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Should_ReturnOk_WhenRequestIsValid()
    {
        //Arrange
        CreateProductCommand command = new()
        {
            Description = "Description",
            Amount = 50,
            Brand = "TestBrand",
            Currency = Modules.Products.Domain.Products.Currency.EUR,
            Name = "Name",
            ProductSubCategoryId = 1,
            UserId = "Test",
            Weight = 50.0
        };

        //Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/Product", command);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Should_ReturnBadRequest_WhenRequestMissingNameAndDescription()
    {
        //Arrange
        CreateProductCommand command = new()
        {
            Description = "TestDescription",
            Amount = 50,
            Brand = "TestBrand",
            Currency = Modules.Products.Domain.Products.Currency.EUR,
            Name = "",
            ProductSubCategoryId = 1,
            UserId = "Test",
            Weight = 50.0
        };

        //Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/Product", command);
        var problemDetails = await response.GetProblemDetails();

        //Assert
        problemDetails.Errors.Errors.Select(x => x.Code).Should().Contain(ProductErrorCodes.CreateProduct.MissingName);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}