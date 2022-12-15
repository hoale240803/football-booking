using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Application.Services
{
    public class StadiumService : BaseService<Stadium>, IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;

        public StadiumService(IBaseRepository<Stadium> baseRepository, IStadiumRepository stadiumRepository) : base(baseRepository)
        {
            _stadiumRepository = stadiumRepository;
        }

        public async Task<IList<StadiumDTO>> GetAvailableStadiumsAsync(QueryParams queryParams)
        {
            return await _stadiumRepository.GetAvailableStadiumsAsync(queryParams);
        }
    }
}