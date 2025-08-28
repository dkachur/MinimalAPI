﻿using Mapster;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application.DTOs
{
    [AdaptFrom(typeof(Product)), GenerateMapper]
    public class ProductDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
