using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.Application.Services;
using MinimalAPI.Application.Validatiors;
using MinimalAPI.Domain.RepositoryContracts;
using MinimalAPI.Infrastructure.DatabaseContext;
using MinimalAPI.Infrastructure.Repositories;
using System.Globalization;

namespace MinimalAPI.WebAPI.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductAdderService, ProductAdderService>();
            services.AddScoped<IProductGetterService, ProductGetterService>();
            services.AddScoped<IProductUpdaterService, ProductUpdaterService>();
            services.AddScoped<IProductDeleterService, ProductDeleterService>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddValidatorsFromAssemblyContaining<AddProductDtoValidator>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
