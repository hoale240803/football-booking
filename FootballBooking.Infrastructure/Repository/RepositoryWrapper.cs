using FootballBooking.Entities;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly FootballBookingDbContext _footballBookingContext;

        private IBookingRepository _booking;
        private IBookerRepository _booker;
        private IStadiumRepository _stadium;
        private IStadiumOwnerRepository _stadiumOwner;

        public RepositoryWrapper(FootballBookingDbContext footballBookingContext)
        {
            _footballBookingContext = footballBookingContext;
        }

        public IBookingRepository Booking
        {
            get
            {
                if (_booking == null)
                {
                    _booking = new BookingRepository(_footballBookingContext);
                    return _booking;
                }
                return _booking;
            }
        }

        public IBookerRepository Booker
        {
            get
            {
                if (_booker == null)
                {
                    _booker = new BookerRepository(_footballBookingContext);
                    return _booker;
                }
                return _booker;
            }
        }

        public IStadiumRepository Stadium
        {
            get
            {
                if (_stadium == null)
                {
                    _stadium = new StadiumRepository(_footballBookingContext);
                    return _stadium;
                }
                return _stadium;
            }
        }

        public IStadiumOwnerRepository StadiumOwner
        {
            get
            {
                if (_stadiumOwner == null)
                {
                    _stadiumOwner = new StadiumOwnerRepository(_footballBookingContext);
                    return _stadiumOwner;
                }
                return _stadiumOwner;
            }
        }

        public void Save()
        {
            _footballBookingContext.SaveChanges();
        }

        public void SaveAsync()
        {
            _footballBookingContext.SaveChangesAsync();
        }
    }
}