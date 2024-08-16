using Application.Abstractions.Caching;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Dapper;
using SharedKernel;
using System.Data;

namespace Modules.Products.Application.ProductCategory.GetAllCategoriesWithSubCategories;

/// <summary>
/// Handler handling the request to download all available categories
/// </summary>
/// <param name="factory"></param>
public class GetAllCategoriesWithSubCategoriesQueryHandler(IDbConnectionFactory factory, ICacheService cacheService) : IQueryHandler<GetAllCategoriesWithSubCategoriesQuery, IEnumerable<GetAllCategoriesWithSubCategoriesResponse>>
{
    public async Task<Result<IEnumerable<GetAllCategoriesWithSubCategoriesResponse>>> Handle(GetAllCategoriesWithSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        const string sql = """
        SELECT
            pc.Id AS CategoryId,
            pc.Name AS CategoryName,
            psc.Id AS SubCategoryId,
            psc.Name AS SubCategoryName
        FROM pcm.product_categories AS pc
        JOIN pcm.product_sub_categories AS psc ON pc.Id = psc.product_category_id
    """;

        using IDbConnection connection = factory.GetOpenConnection();
        var result = await connection.QueryAsync<dynamic>(sql);

        var categories = result
            .GroupBy(x => new { CategoryId = (int)x.categoryid, CategoryName = (string)x.categoryname })
            .Select(g => new GetAllCategoriesWithSubCategoriesResponse(
                g.Select(x => new ProductSubCategoryDto((string)x.subcategoryname, (int)x.subcategoryid)),
                g.Key.CategoryId,
                g.Key.CategoryName));

        return Result.Success(categories);
    }
}