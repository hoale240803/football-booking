using AutoMapper;
using FootballBooking.Application.Exceptions;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs.Req.Auth;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Model;
using FootballBooking.Entities.Resources;
using FootballBooking.Infrastructure.Interface;
using System.Security.Claims;

namespace FootballBooking.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepo, IMapper mapper, ITokenService tokenService, IUserRepository userRepository)
        {
            _authRepository = authRepo;
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<LoginRes> LoginAsync(LoginReq registerReq)
        {
            // Check username existed or not
            var userLogin = await _authRepository.GetUserLoginByUserNameAsync(registerReq.UserName);

            // check password
            if (userLogin != null && IsVerifiedPassword(registerReq.Password, userLogin.HashedPassword))
            {
                var (accessToken, refreshToken) = await GenerateTokenAsync(userLogin, registerReq);
                return new LoginRes
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }

            return new LoginRes();
        }

        private async Task<(string accessToken, string refreshToken)> GenerateTokenAsync(UserLogin user, LoginReq loginModel)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.UserName),
                new Claim(ClaimTypes.Role, "Manager")
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _authRepository.UpdateUserLoginAsync(user);

            return (accessToken, refreshToken);
        }

        private bool IsVerifiedPassword(string password, string hashedPassword)
        {
            // TODO: implement BCRYPT
            return true;
        }

        public async Task<RegisterRes> RegisterAsync(RegisterReq registerReq)
        {
            // TODO: 1 validate unique username
            var isExistingUserName = await _userRepository.IsExistingUserName(registerReq.UserName);
            if (isExistingUserName)
                throw new AppException(ErrorMessages.ExistingUserName);

            // TODO: 2. save user profile
            var userEntity = _mapper.Map<User>(registerReq);
            await _userRepository.AddAsync(userEntity);

            // TODO: 3. save to user login
            var userLogin = new UserLogin
            {
                UserName = registerReq.UserName,
                HashedPassword = registerReq.Password// encrypt password
            };

            await _authRepository.AddUserLoginAsync(userLogin);
            var result = _mapper.Map<RegisterRes>(registerReq);
            return result;
        }
    }
}