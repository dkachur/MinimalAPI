using Mapster;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application.DTOs
{
    [AdaptTo(typeof(Product)), GenerateMapper]
    public record AddProductDto(string Name, string Description, decimal Price);
}
