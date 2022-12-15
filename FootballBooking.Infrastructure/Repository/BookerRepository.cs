using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Base;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class BookerRepository : BaseRepository<Booker>, IBookerRepository
    {
        public BookerRepository(FootballBookingDbContext footballBookingContext) : base(footballBookingContext)
        {
        }
    }
}