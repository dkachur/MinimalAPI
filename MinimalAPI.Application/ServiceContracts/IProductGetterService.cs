using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductGetterService
    {
        Task<ProductDto?> GetAsync(Guid productId);
    }
}
