using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class BookingRepository : BaseRepository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(FootballBookingDbContext footballBookingContext) : base(footballBookingContext)
        {
        }
    }
}