using FluentValidation;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.Validatiors
{ 
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description must be less than 1000 characters long");
            RuleFor(x => x.Price).InclusiveBetween(0, 100000).WithMessage("Price must be between 0 and 100000");
        }
    }
}
