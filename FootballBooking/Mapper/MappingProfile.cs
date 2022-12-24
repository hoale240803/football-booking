using AutoMapper;
using FootballBooking.Entities.DTOs;
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
        }
    }
}