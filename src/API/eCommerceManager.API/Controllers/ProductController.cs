using eCommerceManager.API.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Products.Application.Product.Create;
using Modules.Products.Application.ProductCategory.GetAllCategoriesWithSubCategories;

namespace eCommerceManager.API.Controllers;

public class ProductController(ISender sender) : BaseController
{
    /// <summary>
    /// Returns all available categories with subcategories
    /// </summary>
    /// <param name="query"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("Category")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllCategoriesWithSubCategoriesResponse>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAllCategories(CancellationToken ct)
    {
        var result = await sender.Send(new GetAllCategoriesWithSubCategoriesQuery(), ct);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Insert(CreateProductCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);

        return Created(string.Empty, result);
    }
}