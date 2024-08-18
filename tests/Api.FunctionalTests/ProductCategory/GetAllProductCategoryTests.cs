using Api.FunctionalTests.Abstractions;
using FluentAssertions;
using System.Net;
using Xunit;

namespace Api.FunctionalTests.ProductCategory;

public class GetAllProductCategoryTests : BaseFunctionalTest
{
    public GetAllProductCategoryTests(FunctionalTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Should_ReturnOk_WhenRequestIsValid()
    {
        //Act
        HttpResponseMessage response = await HttpClient.GetAsync("api/v1/Product/Category");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}