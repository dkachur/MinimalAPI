using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Domain.RepositoryContracts;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Product product);
}