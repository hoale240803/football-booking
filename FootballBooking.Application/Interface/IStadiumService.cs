using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;

namespace FootballBooking.Application.Interface
{
    public interface IStadiumService
    {
        Task<IList<StadiumRes>> GetAvailableStadiumsAsync(QueryParams queryParams);

        Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams);

        Task AddStadiumAsync(Stadium stadium);

        Task<StadiumDTO> GetStadiumByIdAsync(Guid id);

        Task UpdateStadiumAsync(Stadium stadium);

        Task DeleteStadiumAsync(Guid stadium);
    }
}