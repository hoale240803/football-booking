using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Moq;

namespace FootballBooking.Test.Repositories
{
    public class MockBookingRepository : Mock<IBookingRepository>
    {
        public MockBookingRepository GetBookings(IList<Booking> bookings)
        {
            Setup(x => x.FindAll()).Returns(bookings.AsQueryable());

            return this;
        }

        public MockBookingRepository GetBookingById(Booking bookingDetails)
        {
            Setup(x => x.GetByIdAsync(bookingDetails.Id)).ReturnsAsync(bookingDetails);

            return this;
        }

        public MockBookingRepository CreateBooking(Booking booking)
        {
            Setup(x => x.AddAsync(booking));

            return this;
        }

        public MockBookingRepository UpdateBooking(Booking booking)
        {
            Setup(x => x.UpdateAsync(booking));

            return this;
        }

        public MockBookingRepository DeleteBooking(Guid bookingId)
        {
            Setup(x => x.DeleteAsync(bookingId));

            return this;
        }
    }
}