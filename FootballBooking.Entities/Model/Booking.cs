using FootballBooking.Entities.Enum;

namespace FootballBooking.Entities.Model
{
    public class Booking : BaseEntity
    {
        /// <summary>
        /// Time book
        /// </summary>
        public DateTime BookTime { get; set; }

        public Guid StadiumId { get; set; }

        public Stadium Stadium { get; set; }

        public Guid BookerId { get; set; }

        public Booker Booker { get; set; }
    }
}