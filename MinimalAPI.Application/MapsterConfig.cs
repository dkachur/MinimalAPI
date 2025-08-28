using Mapster;
using MinimalAPI.Application.DTOs;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddProductDto, Product>()
                .MapWith(src => new Product(
                    new(src.Name), 
                    new(src.Description), 
                    new(src.Price)
                ));

            config.NewConfig<Product, ProductDto>()
                .MapWith(src => new ProductDto() 
                { 
                    Id = src.Id, 
                    Name = src.Name.Value, 
                    Description = src.Description.Value, 
                    Price = src.Price.Value }
                );
        }
    }
}
