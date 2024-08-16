﻿namespace Modules.Products.Application.ProductCategory.GetAllCategoriesWithSubCategories;

public sealed record GetAllCategoriesWithSubCategoriesResponse(IEnumerable<ProductSubCategoryDto> ProductSubCategory, int Id, string Name);