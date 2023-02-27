using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs.Req.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FootballBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginReq req)
        {
            var result = await _authService.LoginAsync(req);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterReq req)
        {
            var result = await _authService.RegisterAsync(req); // thichc choi confict
            var result1 = await _authService.RegisterAsync(req);
            return Ok(result);


        }
    }
}