using Mapster;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application.DTOs
{
    [AdaptTo(typeof(Product)), GenerateMapper]
    public class AddProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
