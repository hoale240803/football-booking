using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IStadiumRepository : IBaseRepository<Stadium>
    {
        Task<IList<StadiumDTO>> GetAvailableStadiumsAsync(QueryParams queryParams);
    }
}