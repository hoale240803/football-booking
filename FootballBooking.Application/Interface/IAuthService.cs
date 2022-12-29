using FootballBooking.Entities.DTOs.Req.Auth;
using FootballBooking.Entities.DTOs.Res;

namespace FootballBooking.Application.Interface
{
    public interface IAuthService
    {
        Task<RegisterRes> RegisterAsync(RegisterReq registerReq);

        Task<LoginRes> LoginAsync(LoginReq registerReq);
    }
}