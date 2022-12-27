using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(FootballBookingDbContext footballBookingContext) : base(footballBookingContext)
        {
        }
    }
}