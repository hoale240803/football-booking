using System.ComponentModel.DataAnnotations;

namespace FootballBooking.Entities.Model
{
    public class Booker : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}