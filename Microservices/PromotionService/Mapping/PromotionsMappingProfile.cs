using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromotionService.DTOs;
using PromotionService.Models;

namespace PromotionService.Mapping
{
    public class PromotionsMappingProfile : Profile
    {
        public PromotionsMappingProfile()
        {
            CreateMap<PromotionDetailRequest, PromotionDetail>();
            CreateMap<PromotionCreateRequest, Promotion>();
            CreateMap<PromotionUpdateRequest, Promotion>();

            CreateMap<PromotionDetail, PromotionDetailResponse>();
            CreateMap<Promotion, PromotionResponse>();
        }
    }
}
