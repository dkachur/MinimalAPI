using MinimalAPI.Application.Errors;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.WebAPI.DTOs;
using MinimalAPI.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.UseHsts();
app.UseRouting();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/products", async (IProductGetterService productGetter) =>
{
    var products = await productGetter.GetAllAsync();
    return Results.Ok(products.Select(p => p.AdaptToProductResponse()));
})
.WithName("GetProducts");


app.MapGet("/products/{id:guid}", async (IProductGetterService productGetter, Guid id) =>
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


app.MapPost("/products", async (IProductAdderService productAdder, AddProductRequest request) =>
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

app.Run();
