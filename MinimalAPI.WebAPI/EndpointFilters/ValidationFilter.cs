using FluentValidation;
using FluentValidation.Results;

namespace MinimalAPI.WebAPI.EndpointFilters
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;
        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var errors = new List<ValidationFailure>();

            foreach(var arg in context.Arguments.OfType<T>())
            {
                var validationResult = await _validator.ValidateAsync(arg);
                if (!validationResult.IsValid)
                    errors.AddRange(validationResult.Errors);
            }

            if (errors.Any())
            {
                var errorResponse = new
                {
                    Errors = errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToList())
                };

                return Results.BadRequest(errorResponse);
            }

            var result = await next(context);

            return result;
        }
    }
}
