using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductService.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCategory, CategoryDto>();
            CreateMap<CategoryCreateRequest, ProductCategory>();

            CreateMap<CategoryVariation, CategoryVariationDto>();
            CreateMap<CategoryVariationCreateRequest, CategoryVariation>();
        }
    }
}
