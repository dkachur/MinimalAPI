using Microsoft.AspNetCore.Mvc;
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
            MapDelete(group);

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
            group.MapGet("/{id:guid}", async (IProductGetterService productGetter, [FromRoute]Guid id) =>
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
            group.MapPut("/{id:guid}", async (IProductUpdaterService productUpdater, [FromRoute]Guid id, [FromBody]UpdateProductRequest request) =>
            {
                if (id != request.Id)
                    return Results.BadRequest($"The product ID from route ('{id}') " +
                        $"does not match the product ID from the request body ('{request.Id}')");

                var result = await productUpdater.UpdateAsync(request.AdaptToUpdateProductDto());
                return result.ToApiResult();
            })
            .WithName("PutProduct");
        }

        private static void MapDelete(RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}", async (IProductDeleterService productDeleter, [FromRoute] Guid id) =>
            {
                var result = await productDeleter.DeleteAsync(id);
                return result.ToApiResult();
            })
            .WithName("DeleteProduct");
        }
    }
}
