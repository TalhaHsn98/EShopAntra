using AutoMapper;
using ShippingService.DTOs;
using ShippingService.Models;

namespace ShippingService.Mapping
{
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperResponseModel>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.EmailId))
                .ForMember(d => d.ContactPerson, o => o.MapFrom(s => s.Contact_Person));

            CreateMap<ShipperRequestModel, Shipper>()
                .ForMember(d => d.EmailId, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Contact_Person, o => o.MapFrom(s => s.ContactPerson));
        }
    }
}
