using FootballBooking.Entities.DTOs.Req.Auth;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IAuthRepository 
    {

        Task<RegisterRes> Register(RegisterReq registerReq);
        Task Login(LoginReq registerReq);
        Task<UserLogin> GetUserLoginByUserNameAsync(string userName);
        Task UpdateUserLoginAsync(UserLogin user);
        Task AddUserLoginAsync(UserLogin user);
        Task<bool> IsExistingUserName(string user);
    }
}