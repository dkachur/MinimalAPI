using Microsoft.EntityFrameworkCore;
using MinimalAPI.Infrastructure.DatabaseContext;
using FluentValidation;
using MinimalAPI.Application.DTOs;
using MinimalAPI.Application.Validatiors;

namespace MinimalAPI.WebAPI.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddValidatorsFromAssemblyContaining<AddProductDtoValidator>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
