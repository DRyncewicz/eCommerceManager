using Application.Abstractions.Caching;

namespace Modules.Products.Application.ProductCategory.GetAllCategoriesWithSubCategories;

public sealed record GetAllCategoriesWithSubCategoriesQuery() : ICachedQuery<IEnumerable<GetAllCategoriesWithSubCategoriesResponse>>
{
    public string CacheKey { get; set; } = ProductCacheKeys.AllProductsCategories;

    public TimeSpan? Expiration { get; set; } = new TimeSpan(8, 0, 0);
}