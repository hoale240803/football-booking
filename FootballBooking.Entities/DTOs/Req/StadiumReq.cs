using FootballBooking.Entities.DTOs.Base;

namespace FootballBooking.Entities.DTOs.Req
{
    public class StadiumReq : StadiumBase
    {
        public AddressDTO Address { get; set; }
    }
}