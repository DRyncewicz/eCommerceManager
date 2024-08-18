using FluentValidation;

namespace Modules.Products.Application.Product.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateProduct.MissingName)
            .MaximumLength(60).WithErrorCode(ProductErrorCodes.CreateProduct.NameToLong);

        RuleFor(p => p.Description)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateProduct.MissingDescription)
            .MaximumLength(1500).WithErrorCode(ProductErrorCodes.CreateProduct.DescriptionToLong);

        RuleFor(p => p.Brand)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateProduct.MissingBrand)
            .MaximumLength(50).WithErrorCode(ProductErrorCodes.CreateProduct.BrandToLong);

        RuleFor(p => p.ProductSubCategoryId)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateProduct.MissingSubCategory);
    }
}