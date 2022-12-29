using FootballBooking.Entities;
using FootballBooking.Entities.DTOs.Req.Auth;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace FootballBooking.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FootballBookingDbContext _dbContext;

        public AuthRepository(FootballBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserLoginAsync(UserLogin user)
        {
            await _dbContext.UserLogin.AddAsync(user);
        }

        public async Task<UserLogin> GetUserLoginByUserNameAsync(string userName)
        {
            return await _dbContext.UserLogin.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<bool> IsExistingUserName(string userName)
        {
            return await _dbContext.UserLogin.AnyAsync(u => u.UserName == userName);
        }

        public Task Login(LoginReq registerReq)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterRes> Register(RegisterReq registerReq)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserLoginAsync(UserLogin user)
        {
            _dbContext.UserLogin.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}