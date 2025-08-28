using FluentResults;

namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductDeleterService
    {
        Task<Result> DeleteAsync(Guid productId);
    }
}
