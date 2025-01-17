using FluentValidation;

namespace Catalog.API.Products.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("{PropertyName} is required"); ;
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleForEach(x => x.Categories).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}