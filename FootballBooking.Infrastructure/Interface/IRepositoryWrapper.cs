namespace FootballBooking.Infrastructure.Interface
{
    public interface IRepositoryWrapper
    {
        public IBookingRepository Booking { get; }
        public IBookerRepository Booker { get; }
        public IStadiumOwnerRepository StadiumOwner { get; }
        public IStadiumRepository Stadium { get; }

        void Save();

        void SaveAsync();
    }
}