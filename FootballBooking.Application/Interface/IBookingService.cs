using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;

namespace FootballBooking.Application.Interface
{
    public interface IBookingService
    {
        Task<PagedList<Booking>> GetBookings(QueryParams queryParams);

        Task<BookingDTO> GetBookingById(Guid id);

        Task AddBookingAsync(Booking booking);

        Task UpdateBookingAsync(Booking booking);

        Task DeleteBookingAsync(Guid id);
    }
}