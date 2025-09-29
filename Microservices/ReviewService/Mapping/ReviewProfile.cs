using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewService.DTOs;
using ReviewService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReviewService.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CustomerReviewCreateDto, CustomerReview>()
                .ForMember(d => d.Customer_Id, m => m.MapFrom(s => s.customerId))
                .ForMember(d => d.Customer_Name, m => m.MapFrom(s => s.customerName))
                .ForMember(d => d.Order_Id, m => m.MapFrom(s => s.orderId))
                .ForMember(d => d.Order_Date, m => m.MapFrom(s => s.orderDate))
                .ForMember(d => d.Product_Id, m => m.MapFrom(s => s.productId))
                .ForMember(d => d.Product_Name, m => m.MapFrom(s => s.productName))
                .ForMember(d => d.Rating_value, m => m.MapFrom(s => s.ratingValue))
                .ForMember(d => d.Comment, m => m.MapFrom(s => s.comment))
                .ForMember(d => d.Review_Date, m => m.MapFrom(s => s.reviewDate.HasValue ? s.reviewDate.Value : DateTime.UtcNow));

            CreateMap<CustomerReview, CustomerReviewResponseDto>()
                .ForMember(d => d.id, m => m.MapFrom(s => s.Id))
                .ForMember(d => d.customerId, m => m.MapFrom(s => s.Customer_Id))
                .ForMember(d => d.customerName, m => m.MapFrom(s => s.Customer_Name))
                .ForMember(d => d.orderId, m => m.MapFrom(s => s.Order_Id))
                .ForMember(d => d.orderDate, m => m.MapFrom(s => s.Order_Date))
                .ForMember(d => d.productId, m => m.MapFrom(s => s.Product_Id))
                .ForMember(d => d.productName, m => m.MapFrom(s => s.Product_Name))
                .ForMember(d => d.ratingValue, m => m.MapFrom(s => s.Rating_value))
                .ForMember(d => d.comment, m => m.MapFrom(s => s.Comment))
                .ForMember(d => d.reviewDate, m => m.MapFrom(s => s.Review_Date))
                .ForMember(d => d.status, m => m.MapFrom(s => s.Status.ToString()));
        }
    }
}
