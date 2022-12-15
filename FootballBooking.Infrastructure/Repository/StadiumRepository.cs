using FootballBooking.Entities;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Enum;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Base;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace FootballBooking.Infrastructure.Repository
{
    public class StadiumRepository : BaseRepository<Stadium>, IStadiumRepository
    {
        private readonly FootballBookingDbContext _dbContext;

        public StadiumRepository(FootballBookingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<StadiumDTO>> GetAvailableStadiumsAsync(QueryParams queryParams)
        {
            try
            {
                var availableStadiumQuery = from stadium in _dbContext.Stadium
                                            join stadiumOwner in _dbContext.StadiumOwner on stadium.StadiumOwnerId equals stadiumOwner.Id
                                            orderby stadium.StadiumStatus
                                            select new StadiumDTO
                                            {
                                                Id = stadium.Id,
                                                Name = stadium.Name,
                                                Price = stadium.Price,
                                                OwnerId = stadiumOwner.Id,
                                                OwnerName = stadiumOwner.Name,
                                                PhoneNumber = stadiumOwner.PhoneNumber,
                                                Address = stadium.Address.Street,
                                                StadiumStatus = stadium.StadiumStatus,
                                            };

                var availabelStadiums = await availableStadiumQuery
                    .Where(s => s.StadiumStatus == StadiumStatusEnum.Available)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                return availabelStadiums;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}