namespace MinimalAPI.Application.ServiceContracts
{
    public interface IProductDeleterService
    {
        Task<bool> UpdateAsync(Guid productId);
    }
}
