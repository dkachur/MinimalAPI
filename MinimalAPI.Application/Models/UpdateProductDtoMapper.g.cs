using MinimalAPI.Application.DTOs;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.ValueObjects;

namespace MinimalAPI.Application.DTOs
{
    public static partial class UpdateProductDtoMapper
    {
        public static Product AdaptToProduct(this UpdateProductDto src)
        {
            return Product.Restore(src.Id, new ProductName(src.Name), new ProductDescription(src.Description), new ProductPrice(src.Price));
        }
        public static Product AdaptTo(this UpdateProductDto src, Product p1)
        {
            return Product.Restore(src.Id, new ProductName(src.Name), new ProductDescription(src.Description), new ProductPrice(src.Price));
        }
    }
}