using FluentResults;
using FluentValidation;
using MinimalAPI.Application.DTOs;
using MinimalAPI.Application.Errors;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.Domain.RepositoryContracts;

namespace MinimalAPI.Application.Services
{
    public class ProductGetterService : IProductGetterService
    {
        private readonly IProductsRepository _repo;

        public ProductGetterService(IProductsRepository repo) => _repo = repo;

        public async Task<Result<ProductDto>> GetAsync(Guid productId)
        {
            var product = await _repo.GetByIdAsync(productId);

            if (product is null)
                return Result.Fail<ProductDto>(new NotFoundError($"Product with id {productId} does not exist."));

            return Result.Ok(product.AdaptToProductDto());
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(p => p.AdaptToProductDto());
    }
}
