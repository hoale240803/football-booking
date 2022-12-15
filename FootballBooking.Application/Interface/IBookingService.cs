using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;

namespace FootballBooking.Application.Interface
{
    public interface IBookingService: IBaseService<Booking>
    {
        Task<PagedList<Booking>> GetBookings(QueryParams queryParams);
    }
}