using FluentResults;
using MinimalAPI.Application.DTOs;
using MinimalAPI.Application.Errors;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.Extensions
{
    public static class ResultExtension
    {
        public static IResult ToApiResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
            {
                if (result.Value is ProductDto dto)
                    return Results.Ok(dto.AdaptToProductResponse());

                return Results.Ok(result.Value);
            }

            return ConvertToErrorResult(result.ToResult());
        }

        public static IResult ToApiResult(this Result result)
        {
            if (result.IsSuccess)
                return Results.NoContent();

            return ConvertToErrorResult(result);
        }

        private static IResult ConvertToErrorResult(Result result)
        {
            var error = result.Errors.FirstOrDefault();
            var response = new ErrorResponse(error?.Message);

            return error switch
            {
                ValidationError => Results.BadRequest(response),
                NotFoundError => Results.NotFound(response),
                ConflictError => Results.Conflict(response),
                DeleteFailedError => Results.InternalServerError(response),
                _ => Results.InternalServerError(response)
            };
        }
    }
}
