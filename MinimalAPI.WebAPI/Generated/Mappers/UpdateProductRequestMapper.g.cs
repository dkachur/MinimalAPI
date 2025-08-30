using MinimalAPI.Application.DTOs;
using MinimalAPI.WebAPI.DTOs;

namespace MinimalAPI.WebAPI.DTOs
{
    public static partial class UpdateProductRequestMapper
    {
        public static UpdateProductDto AdaptToUpdateProductDto(this UpdateProductRequest p1)
        {
            return p1 == null ? null : new UpdateProductDto(p1.Id, p1.Name, p1.Description, p1.Price) {};
        }
        public static UpdateProductDto AdaptTo(this UpdateProductRequest p2, UpdateProductDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UpdateProductDto result = new UpdateProductDto(p2.Id, p2.Name, p2.Description, p2.Price) {};
            return result;
            
        }
    }
}