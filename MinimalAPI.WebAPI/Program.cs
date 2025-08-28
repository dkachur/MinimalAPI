using MinimalAPI.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.UseHsts();
app.UseRouting();

app.MapGet("/", () => {

});

app.Run();
