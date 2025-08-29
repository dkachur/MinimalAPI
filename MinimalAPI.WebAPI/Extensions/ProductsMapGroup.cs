using MinimalAPI.Application.Errors;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.Extensions
{
    public static class ProductsMapGroup
    {
        public static RouteGroupBuilder MapProducts(this RouteGroupBuilder group)
        {
            MapGetAll(group);
            MapGetById(group);
            MapPost(group);

            return group;
        }

        private static void MapGetAll(RouteGroupBuilder group)
        {
            group.MapGet("/", async (IProductGetterService productGetter) =>
            {
                var products = await productGetter.GetAllAsync();
                return Results.Ok(products.Select(p => p.AdaptToProductResponse()));
            })
            .WithName("GetProducts");
        }

        private static void MapGetById(RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IProductGetterService productGetter, Guid id) =>
            {
                var result = await productGetter.GetByIdAsync(id);

                if (result.IsSuccess)
                    return Results.Ok(result.Value.AdaptToProductResponse());

                var error = result.Errors.FirstOrDefault();

                return error switch
                {
                    ValidationError => Results.BadRequest(error),
                    NotFoundError => Results.NotFound(error),
                    _ => Results.InternalServerError(error)
                };
            })
            .WithName("GetProduct");
        }

        private static void MapPost(RouteGroupBuilder group)
        {
            group.MapPost("", async (IProductAdderService productAdder, AddProductRequest request) =>
            {
                var result = await productAdder.AddAsync(request.AdaptToAddProductDto());

                if (result.IsSuccess)
                    return Results.Ok(result.Value.AdaptToProductResponse());

                var error = result.Errors.FirstOrDefault();

                return error switch
                {
                    ValidationError => Results.BadRequest(error),
                    _ => Results.InternalServerError(error)
                };
            })
            .WithName("PostProduct");
        }
    }
}
