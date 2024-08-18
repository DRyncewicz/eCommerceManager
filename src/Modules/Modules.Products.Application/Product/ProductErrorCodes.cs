namespace Modules.Products.Application.Product;

public static class ProductErrorCodes
{
    public static class CreateProduct
    {
        public const string MissingName = nameof(MissingName);
        public const string MissingDescription = nameof(MissingDescription);
        public const string MissingSubCategory = nameof(MissingSubCategory);
        public const string MissingBrand = nameof(MissingBrand);

        public const string NameToLong = nameof(NameToLong);
        public const string DescriptionToLong = nameof(DescriptionToLong);
        public const string BrandToLong = nameof(BrandToLong);
    }
}