using MinimalAPI.Application.DTOs;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application.DTOs
{
    public static partial class ProductDtoMapper
    {
        public static ProductDto AdaptToProductDto(this Product src)
        {
            return new ProductDto()
            {
                Id = src.Id,
                Name = src.Name.Value,
                Description = src.Description.Value,
                Price = src.Price.Value
            };
        }
        public static ProductDto AdaptTo(this Product src, ProductDto p1)
        {
            return new ProductDto()
            {
                Id = src.Id,
                Name = src.Name.Value,
                Description = src.Description.Value,
                Price = src.Price.Value
            };
        }
    }
}