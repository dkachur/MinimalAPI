using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductUpdaterService
    {
        Task<ProductDto?> UpdateAsync(UpdateProductDto product);
    }
}
