using AutoMapper;
using FootballBooking.Application.Interface;
using FootballBooking.Application.Services;
using FootballBooking.Controllers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Moq;

namespace FootballBooking.Test
{
    public class BookingControllerTest
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingService _bookingService;
        private readonly BookingsController _bookingController;

        private readonly IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var mockBaseRepository = new Mock<IBaseRepository<Booking>>();
            var mockBaseService = new Mock<IBaseService<Booking>>();
            var mockBookingService = new BookingService(mockBaseRepository.Object, mockBaseService.Object);

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}