using MinimalAPI.Application.DTOs;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.ValueObjects;

namespace MinimalAPI.Application.DTOs
{
    public static partial class AddProductDtoMapper
    {
        public static Product AdaptToProduct(this AddProductDto src)
        {
            return Product.New(new ProductName(src.Name), new ProductDescription(src.Description), new ProductPrice(src.Price));
        }
        public static Product AdaptTo(this AddProductDto src, Product p1)
        {
            return Product.New(new ProductName(src.Name), new ProductDescription(src.Description), new ProductPrice(src.Price));
        }
    }
}