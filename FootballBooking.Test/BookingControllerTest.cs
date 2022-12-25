using AutoMapper;
using FootballBooking.Application.Interface;
using FootballBooking.Application.Services;
using FootballBooking.Controllers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Test.Repositories;
using Moq;

namespace FootballBooking.Test
{
 
    public class BookingControllerTest
    {


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

        [Test]
        public void Test2()
        {
            //Assert.Pass();
            StadiumRepositoryTest stadiumRepositoryTest = new StadiumRepositoryTest();
            //stadiumRepositoryTest.Test1();
        }
    }
}