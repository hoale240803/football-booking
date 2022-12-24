using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IStadiumRepository : IBaseRepository<Stadium>
    {
        Task<IList<StadiumRes>> GetAvailableStadiumsAsync(QueryParams queryParams);

        Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams);
        Task<bool> IsExistingStadiumNameAsync(string stadiumName);
    }
}