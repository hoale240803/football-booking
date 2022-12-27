using Dapper;
using FootballBooking.Entities;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Enum;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FootballBooking.Infrastructure.Repository
{
    public class StadiumRepository : BaseRepository<Stadium, Guid>, IStadiumRepository
    {
        private readonly FootballBookingDbContext _dbContext;

        public StadiumRepository(FootballBookingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateStadiumAsync(Stadium stadium)
        {
            await AddAsync(stadium);
        }

        public async Task DeleteStadiumAsync(Stadium stadiumId)
        {
            await DeleteAsync(stadiumId);
        }

        public async Task<IList<StadiumRes>> GetAvailableStadiumsAsync(QueryParams queryParams)
        {
            try
            {
                var availableStadiumQuery = from stadium in _dbContext.Stadium
                                            from address in _dbContext.Address
                                            from stadiumOwner in _dbContext.User
                                            where stadium.Id == address.StadiumId && stadium.StadiumOwnerId == stadiumOwner.Id
                                            && stadiumOwner.UserType == UserType.StadiumOwner
                                            orderby stadium.StadiumStatus
                                            select new StadiumRes
                                            {
                                                Id = stadium.Id,
                                                Name = stadium.Name,
                                                Price = stadium.Price,
                                                OwnerId = stadiumOwner.Id,
                                                OwnerName = stadiumOwner.FirstName,
                                                PhoneNumber = stadiumOwner.PhoneNumber,
                                                Address = address.Street,
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

        public async Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams)
        {
            var query = $"SELECT DISTINCT S.Id as Id, S.Name as Name, S.Price AS Price, S.StadiumStatus AS StadiumStatus, SO.[FirstName] AS OwerName, SO.[PhoneNumber] as PhoneNumber FROM Stadium AS S,[User] AS SO, Address AS A  WHERE S.StadiumOwnerId = SO.Id AND S.Id = A.StadiumId AND A.City LIKE @City OR S.[Name] LIKE @Name";

            var parameters = new DynamicParameters();
            parameters.Add("Name", "%" + stadiumParams.Name.Trim().ToLower() + "%", DbType.String);
            parameters.Add("City", "%" + stadiumParams.Address?.City.Trim().ToLower() + "%", DbType.String);

            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                try
                {
                    using (var transation = new DatabaseTransaction(_dbContext))
                    {
                        var stadiums = await connection.QueryAsync<StadiumDTO>(query, parameters);

                        transation.Commit();

                        return PagedList<StadiumDTO>.ToPagedList(stadiums, stadiumParams.PageNumber, stadiumParams.PageSize);
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void SearchByCity(ref IQueryable<Stadium> stadiums, string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return;
        }

        public Task UpdateStadiumAsync(Stadium stadium)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistingStadiumNameAsync(string stadiumName)
        {
            return _dbContext.Stadium.AnyAsync(s => s.Name.Contains(stadiumName));
        }
    }
}