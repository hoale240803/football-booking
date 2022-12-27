using AutoMapper;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Model;
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

        // GET api/stadiums/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableStadiums([FromQuery] QueryParams queryParams)
        {
            var result = await _stadiumService.GetAvailableStadiumsAsync(queryParams);
            return Ok(result);
        }

        // POST api/stadiums
        [HttpPost("search")]
        public async Task<IActionResult> GetStadiums([FromBody] StadiumParams queryParams)
        {
            var result = await _stadiumService.GetStadiumsAsync(queryParams);
            return Ok(result);
        }

        // GET api/stadiums/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStadiums(Guid id)
        {
            var result = await _stadiumService.GetStadiumByIdAsync(id);
            return Ok(result);
        }

        // POST api/stadiums
        [HttpPost]
        public async Task CreateStadium([FromBody] StadiumDTO stadium)
        {
            stadium.ValidateStadium();
            var stadiumEntity = _mapper.Map<Stadium>(stadium);
            await _stadiumService.AddStadiumAsync(stadiumEntity);
        }

        // PUT api/stadiums
        [HttpPut]
        public async Task UpdateStadium([FromBody] StadiumDTO stadium)
        {
            var stadiumEntity = _mapper.Map<Stadium>(stadium);
            await _stadiumService.UpdateStadiumAsync(stadiumEntity);
        }

        // DELETE api/stadiums/{id}
        [HttpDelete]
        public async Task DeleteStadium(Guid id)
        {
            await _stadiumService.DeleteStadiumAsync(id);
        }
    }
}