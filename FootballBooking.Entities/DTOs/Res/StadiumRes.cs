using FootballBooking.Entities.DTOs.Base;

namespace FootballBooking.Entities.DTOs.Res
{
    public class StadiumRes : StadiumBase
    {
        public Guid AddressId { get; set; }
        public string Address { get; set; }
    }
}