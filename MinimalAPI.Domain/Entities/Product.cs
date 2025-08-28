using MinimalAPI.Domain.ValueObjects;

namespace MinimalAPI.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public ProductName Name { get; set; } = null!;
        public ProductDescription Description { get; set; } = null!;
        public ProductPrice Price { get; set; } = null!;

        public static Product New(ProductName name, ProductDescription description, ProductPrice price)
            => new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
            };
            
        public static Product Restore(Guid id, ProductName name, ProductDescription description, ProductPrice price)
            => new() 
            { 
                Id = id, 
                Name = name, 
                Description = description, 
                Price = price 
            };

        private Product() { }
    }
}
