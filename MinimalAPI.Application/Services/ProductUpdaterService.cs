using FluentResults;
using FluentValidation;
using MinimalAPI.Application.DTOs;
using MinimalAPI.Application.Errors;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.Domain.RepositoryContracts;

namespace MinimalAPI.Application.Services
{
    public class ProductUpdaterService : IProductUpdaterService
    {
        private readonly IProductsRepository _repo;
        private readonly IValidator<UpdateProductDto> _validator;

        public ProductUpdaterService(IProductsRepository repo, IValidator<UpdateProductDto> validator)
        {
            _repo = repo;
            _validator = validator;
        }


        public async Task<Result<ProductDto>> UpdateAsync(UpdateProductDto product)
        {
            var validRes = await _validator.ValidateAsync(product);
            if (!validRes.IsValid)
                return Result.Fail<ProductDto>(validRes.Errors.Select(e => new ValidationError(e.ErrorMessage)));

            var target = await _repo.GetByIdAsync(product.Id);
            if (target is null)
                return Result.Fail<ProductDto>(new NotFoundError($"Product with ID {product.Id} does not exist."));

            var updatedProduct = await _repo.UpdateAsync(product.AdaptToProduct());
            return updatedProduct.AdaptToProductDto();
        }
    }
}
