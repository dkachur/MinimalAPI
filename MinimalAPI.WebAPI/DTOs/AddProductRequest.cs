using Mapster;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.WebAPI.DTOs
{
    [AdaptTo(typeof(AddProductDto)), GenerateMapper]
    public record AddProductRequest(string Name, string Description, decimal Price);
}
