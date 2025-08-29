using MinimalAPI.Application.DTOs;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.DTOs
{
    public static partial class AddProductRequestMapper
    {
        public static AddProductDto AdaptToAddProductDto(this AddProductRequest p1)
        {
            return p1 == null ? null : new AddProductDto(p1.Name, p1.Description, p1.Price) {};
        }
        public static AddProductDto AdaptTo(this AddProductRequest p2, AddProductDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AddProductDto result = new AddProductDto(p2.Name, p2.Description, p2.Price) {};
            return result;
            
        }
    }
}