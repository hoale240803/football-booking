using AutoMapper;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : ControllerBase
    {

        private readonly IStadiumService _stadiumService;
        private readonly IMapper _mapper;

        public StadiumsController(IMapper mapper, IStadiumService stadiumService)
        {
            _mapper = mapper;
            _stadiumService = stadiumService;
        }

        // GET api/stadium/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableStadiums([FromQuery] QueryParams queryParams)
        {
            return Ok(await _stadiumService.GetAvailableStadiumsAsync(queryParams));
        }
    }
}
