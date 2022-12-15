using FootballBooking.Entities.Enum;

namespace FootballBooking.Entities.DTOs
{
    public class StadiumDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public Guid AddressId { get; set; }
        public string Address { get; set; }
        public StadiumStatusEnum StadiumStatus { get; set; }

        // Properties Owner
        public Guid OwnerId { get; set; }

        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}