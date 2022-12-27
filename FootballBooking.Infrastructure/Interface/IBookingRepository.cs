using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IBookingRepository : IBaseRepository<Booking, Guid>
    {
    }
}