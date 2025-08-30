using Mapster;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.WebAPI.DTOs
{
    [AdaptTo(typeof(UpdateProductDto)), GenerateMapper]
    public record UpdateProductRequest(Guid Id, string Name, string Description, decimal Price);
}
