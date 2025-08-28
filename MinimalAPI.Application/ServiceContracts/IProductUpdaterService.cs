using FluentResults;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductUpdaterService
    {
        Task<Result<ProductDto>> UpdateAsync(UpdateProductDto product);
    }
}
