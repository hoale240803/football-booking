namespace FootballBooking.Infrastructure.Interface
{
    public interface IWrapperRepository
    {
        public IBookingRepository Booking { get; }
        public IBookerRepository Booker { get; }
        public IStadiumOwnerRepository StadiumOwner { get; }
        public IStadiumRepository Stadium { get; }
        public IAddressRepository Address { get; }

        IDatabaseTransaction BeginTransaction();

        void Save();

        Task SaveAsync();
    }
}