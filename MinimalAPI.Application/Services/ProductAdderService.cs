using FluentResults;
using FluentValidation;
using MinimalAPI.Application.DTOs;
using MinimalAPI.Application.Errors;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.Domain.RepositoryContracts;

namespace MinimalAPI.Application.Services
{
    public class ProductAdderService : IProductAdderService
    {
        private readonly IProductsRepository _repo;
        private readonly IValidator<AddProductDto> _validator;

        public ProductAdderService(IProductsRepository repo, IValidator<AddProductDto> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<Result<ProductDto>> AddAsync(AddProductDto productDto)
        {
            var validationResult = await _validator.ValidateAsync(productDto);
            if (!validationResult.IsValid)
                return Result.Fail<ProductDto>(validationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)));
            
            var addedProduct = await _repo.AddAsync(productDto.AdaptToProduct());

            return Result.Ok(addedProduct.AdaptToProductDto());
        }
    }
}
