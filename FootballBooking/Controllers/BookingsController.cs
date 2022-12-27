using AutoMapper;
using FootballBooking.ActionFilters;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootballBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<IActionResult> GetBookings([FromQuery] QueryParams searchParams)
        {
            var result = _mapper.Map<IList<BookingDTO>>(await _bookingService.GetBookings(searchParams));
            return Ok(result);
        }

        // GET api/bookings/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var booking = await _bookingService.GetBookingById(id);

            var result = _mapper.Map<BookingDTO>(booking);

            return Ok(result);
        }

        // POST api/bookings
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO booking)
        {
            var bookingEntity = _mapper.Map<Booking>(booking);

            await _bookingService.AddBookingAsync(bookingEntity);

            return Ok(true);
        }

        // PUT api/bookings/5
        [HttpPut("{id}")]
        public async Task UpdateBooking(Guid Id, [FromBody] BookingDTO booking)
        {
            var bookingEntity = _mapper.Map<Booking>(booking);
            bookingEntity.Id = Id;
            await _bookingService.UpdateBookingAsync(bookingEntity);
        }

        // DELETE api/bookings/5
        [HttpDelete("{id}")]
        public async Task DeleteBooking(Guid id)
        {
            await _bookingService.DeleteBookingAsync(id);
        }
    }
}