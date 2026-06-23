using Application.DTOs;
using FluentValidation;
namespace Application.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(255).WithMessage("Product name must not exceed 255 characters.");

            RuleForEach(x => x.Items).SetValidator(new ItemCreateDtoValidator());
        }
    }

    public class ItemCreateDtoValidator : AbstractValidator<ItemCreateDto>
    {
        public ItemCreateDtoValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
   
}
