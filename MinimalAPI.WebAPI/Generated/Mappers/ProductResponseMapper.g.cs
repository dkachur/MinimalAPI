using MinimalAPI.Application.DTOs;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.DTOs
{
    public static partial class ProductResponseMapper
    {
        public static ProductResponse AdaptToProductResponse(this ProductDto p1)
        {
            return p1 == null ? null : new ProductResponse(p1.Id, p1.Name, p1.Description, p1.Price) {};
        }
        public static ProductResponse AdaptTo(this ProductDto p2, ProductResponse p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ProductResponse result = new ProductResponse(p2.Id, p2.Name, p2.Description, p2.Price) {};
            return result;
            
        }
    }
}