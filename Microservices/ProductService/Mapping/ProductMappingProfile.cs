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



            CreateMap<ProductCreateRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.VariationValueIds, m => m.MapFrom(s => s.VariationValues.Select(v => v.VariationValueId)));

            CreateMap<VariationValueCreateRequest, VariationValue>();
            CreateMap<VariationValue, VariationValueDto>();
        }
    }
}
