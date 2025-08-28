using FluentResults;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductGetterService
    {
        Task<Result<ProductDto>> GetAsync(Guid productId);

        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}
