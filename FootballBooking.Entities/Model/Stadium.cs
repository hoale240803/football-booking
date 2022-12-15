using FootballBooking.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace FootballBooking.Entities.Model
{
    public class Stadium : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }

        public int Price { get; set; }
        public StadiumStatusEnum StadiumStatus { get; set; }

        public Address Address { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Guid StadiumOwnerId { get; set; }
        public StadiumOwner StadiumOwner { get; set; }


    }
}