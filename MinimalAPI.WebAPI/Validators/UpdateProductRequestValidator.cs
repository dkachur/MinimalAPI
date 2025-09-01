using FluentValidation;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Price).InclusiveBetween(1, 100000);
        }
    }
}
