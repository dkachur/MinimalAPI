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
            MapPut(group);

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
                return result.ToApiResult();
            })
            .WithName("GetProduct");
        }

        private static void MapPost(RouteGroupBuilder group)
        {
            group.MapPost("/", async (IProductAdderService productAdder, AddProductRequest request) =>
            {
                var result = await productAdder.AddAsync(request.AdaptToAddProductDto());
                return result.ToApiResult();
            })
            .WithName("PostProduct");
        }

        private static void MapPut(RouteGroupBuilder group)
        {
            group.MapPut("/", async (IProductUpdaterService productUpdater, UpdateProductRequest request) =>
            {
                var result = await productUpdater.UpdateAsync(request.AdaptToUpdateProductDto());
                return result.ToApiResult();
            })
            .WithName("PutProduct");
        }
    }
}
