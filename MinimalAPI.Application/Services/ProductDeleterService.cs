using FluentResults;
using MinimalAPI.Application.Errors;
using MinimalAPI.Application.ServiceContracts;
using MinimalAPI.Domain.RepositoryContracts;

namespace MinimalAPI.Application.Services
{
    public class ProductDeleterService : IProductDeleterService
    {
        private readonly IProductsRepository _repo;

        public ProductDeleterService(IProductsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> DeleteAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                return Result.Fail(new ValidationError("Product ID must not be empty."));
            
            var target = await _repo.GetByIdAsync(productId);
            if (target is null)
                return Result.Fail(new NotFoundError($"Product with ID {productId} does not exist."));

            bool deleted = await _repo.DeleteAsync(target);
            if (deleted)
                return Result.Ok();
            else
                return Result.Fail(new DeleteFailedError($"Product with ID {productId} was not deleted."));
        }
    }
}
