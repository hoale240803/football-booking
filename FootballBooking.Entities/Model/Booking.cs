using FootballBooking.Entities.Enum;

namespace FootballBooking.Entities.Model
{
    public class Booking : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime BookTime { get; set; }
        public Guid StadiumId { get; set; }
        public Guid BookerId { get; set; }

        public virtual User Booker { get; set; } = null!;
    }
}