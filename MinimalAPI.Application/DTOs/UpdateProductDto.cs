namespace MinimalAPI.Application.DTOs
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; } 
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; } 
    }
}