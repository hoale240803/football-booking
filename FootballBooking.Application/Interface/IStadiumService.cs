using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Model;

namespace FootballBooking.Application.Interface
{
    public interface IStadiumService : IBaseService<Stadium>
    {
        Task<IList<StadiumDTO>> GetAvailableStadiumsAsync(QueryParams queryParams);
    }
}