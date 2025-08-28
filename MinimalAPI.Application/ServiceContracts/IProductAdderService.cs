using FluentResults;
using MinimalAPI.Application.DTOs;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductAdderService
    {
        Task<Result<ProductDto>> AddAsync(AddProductDto productDto);
    }
}
