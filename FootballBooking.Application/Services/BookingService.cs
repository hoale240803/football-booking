using AutoMapper;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        public async Task<PagedList<Booking>> GetBookings(QueryParams queryParams)
        {
            var result = await _bookingRepo.FindAllAsync();
            var pagedList = PagedList<Booking>.ToPagedList(result, queryParams.PageNumber, queryParams.PageSize);

            return pagedList;
        }

        public async Task<BookingDTO> GetBookingById(Guid id)
        {
            var result = _mapper.Map<BookingDTO>(await _bookingRepo.GetByIdAsync(id));
            return result;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepo.AddAsync(booking);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _bookingRepo.UpdateAsync(booking);
        }

        public async Task DeleteBookingAsync(Guid id)
        {
            await _bookingRepo.DeleteAsync(id);
        }
    }
}