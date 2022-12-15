using FootballBooking.Entities.Enum;

namespace FootballBooking.Entities.DTOs
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public StadiumStatusEnum StadiumStatus { get; set; }

        /// <summary>
        /// Time book
        /// </summary>
        public DateTime BookTime { get; set; }

        public Guid StadiumId { get; set; }

        public Guid BookerId { get; set; }
    }
}