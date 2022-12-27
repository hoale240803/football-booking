using FootballBooking.Entities;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class WrapperRepository : IWrapperRepository, IDisposable
    {
        private readonly FootballBookingDbContext _footballBookingContext;

        private IBookingRepository? _booking;
        private IStadiumRepository? _stadium;
        private IAddressRepository? _address;
        private IUserRepository? _user;

        public WrapperRepository(FootballBookingDbContext footballBookingContext)
        {
            _footballBookingContext = footballBookingContext;
        }

        public WrapperRepository() : this(new FootballBookingDbContext())
        {
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

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_footballBookingContext);
                    return _user;
                }
                return _user;
            }
        }

        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_footballBookingContext);
                    return _address;
                }
                return _address;
            }
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(_footballBookingContext);
        }

        public void Save()
        {
            _footballBookingContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _footballBookingContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
            if (disposing)
            {
                // free managed resources
                //_footballBookingContext.Dispose();
            }
        }
    }
}