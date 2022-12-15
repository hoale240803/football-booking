using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Base;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class StadiumOwnerRepository : BaseRepository<StadiumOwner>, IStadiumOwnerRepository
    {
        public StadiumOwnerRepository(FootballBookingDbContext footballBookingContext) : base(footballBookingContext)
        {
        }
    }
}