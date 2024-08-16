using SharedKernel;

namespace Modules.Products.Domain.Products;

public static class ProductErrors
{
    public static Error NotFound(int userId) => Error.NotFound(
    "Product.NotFound",
    $"The product with the Id = '{userId}' was not found");

    public static Error Failure() => Error.Failure("Can't create product",
        "Unexpected error occurs while trying to add new product");
}