using Mapster;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.WebAPI.DTOs
{
    [AdaptFrom(typeof(ProductDto)), GenerateMapper]
    public record ProductResponse(Guid Id, string Name, string Description, decimal Price);
}
