using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace FootballBooking.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private readonly FootballBookingDbContext _dbContext;

        public UserRepository(FootballBookingDbContext footballBookingContext) : base(footballBookingContext)
        {
            _dbContext = footballBookingContext;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            var result = await _dbContext.User.FirstOrDefaultAsync(u => u.UserName == userName);

            return result;
        }

        public async Task<bool> IsExistingUserName(string userName)
        {
            var result = await _dbContext.User.AnyAsync(u => u.UserName == userName);

            return result;
        }
    }
}