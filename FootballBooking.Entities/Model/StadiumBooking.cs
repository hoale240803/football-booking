using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBooking.Entities.Model
{
    public class StadiumBooking : BaseEntity<Guid>
    {
        public Guid BookingId { get; set; }
        public Guid StadiumId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Stadium Stadium { get; set; } = null!;
    }
}