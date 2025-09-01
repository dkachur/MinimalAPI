using FluentValidation;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Price).InclusiveBetween(1, 100000);
        }
    }
}
