using FluentValidation;

namespace Catalog.API.Products.Create;

public class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("{PropertyName} is required");
    }
}