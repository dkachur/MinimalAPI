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

var mapGroup = app.MapGroup("products").MapProducts();

app.Run();
