using MinimalAPI.WebAPI.Extensions;

namespace MinimalAPI.WebAPI.EndpointFilters
{
    public class RequireBodyFilter<T> : IEndpointFilter where T : class
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            if (context.Arguments.OfType<T>().FirstOrDefault() is null)
                return Results.BadRequest(new ErrorResponse("Request body is required."));

            var result = await next(context);

            return result;
        }
    }
}
