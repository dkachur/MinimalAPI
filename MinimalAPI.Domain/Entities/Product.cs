using MinimalAPI.Domain.ValueObjects;

namespace MinimalAPI.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public ProductName Name { get; set; } = null!;
        public ProductDescription Description { get; set; } = null!;
        public ProductPrice Price { get; set; } = null!;

        public Product(ProductName name, ProductDescription description, ProductPrice price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }

        private Product() { }
    }
}
