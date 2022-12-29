using AutoMapper;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Req.Auth;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Model;

namespace FootballBooking.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingDTO, Booking>().ReverseMap();
            CreateMap<StadiumDTO, Stadium>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();

            // service layer
            CreateMap<RegisterReq, User>().ReverseMap();
            CreateMap<RegisterRes, RegisterReq>().ReverseMap();
        }
    }
}