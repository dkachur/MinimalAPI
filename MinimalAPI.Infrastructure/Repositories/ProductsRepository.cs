using Microsoft.EntityFrameworkCore;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.RepositoryContracts;
using MinimalAPI.Infrastructure.DatabaseContext;

namespace MinimalAPI.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var addedProduct = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            addedProduct.State = EntityState.Detached;
            return addedProduct.Entity;
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            var rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _dbContext.Products.AsNoTracking().ToListAsync();   

        public async Task<Product?> GetByIdAsync(Guid id)
            => await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        

        public async Task<Product> UpdateAsync(Product product)
        {
            var updatedProduct = _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();

            updatedProduct.State = EntityState.Detached;
            return updatedProduct.Entity;
        }
    }
}
