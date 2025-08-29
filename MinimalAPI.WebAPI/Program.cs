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

app.Run();
