using Mapster;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application.DTOs
{
    [AdaptTo(typeof(Product)), GenerateMapper]
    public record UpdateProductDto(Guid Id, string Name, string Description, decimal Price);
}