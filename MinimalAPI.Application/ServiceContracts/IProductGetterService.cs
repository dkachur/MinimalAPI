using FluentResults;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductGetterService
    {
        Task<Result<ProductDto>> GetByIdAsync(Guid productId);

        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}
