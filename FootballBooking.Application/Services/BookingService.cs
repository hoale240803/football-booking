using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Application.Services
{
    public class BookingService : BaseService<Booking>, IBookingService
    {
        private readonly IBaseService<Booking> _baseService;

        public BookingService(IBaseRepository<Booking> baseRepository, IBaseService<Booking> baseService) : base(baseRepository)
        {
            _baseService = baseService;
        }

        public async Task<PagedList<Booking>> GetBookings(QueryParams queryParams)
        {
            var bookings = await _baseService.GetAllAsync(queryParams);

            return PagedList<Booking>.ToPagedList(bookings.AsQueryable(), queryParams.PageNumber, queryParams.PageSize);
        }


    }
}