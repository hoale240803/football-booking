using Dapper;
using FootballBooking.Entities;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Enum;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FootballBooking.Infrastructure.Repository
{
    public class StadiumRepository : BaseRepository<Stadium>, IStadiumRepository
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

        public async Task DeleteStadiumAsync(Guid stadiumId)
        {
            await DeleteAsync(stadiumId);
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

        public async Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams)
        {
            //var stadiums = from stadium in _dbContext.Stadium
            //               join stadiumOwner in _dbContext.StadiumOwner  on stadium.StadiumOwnerId equals stadiumOwner.Id
            //               where stadium.Address.City.Contains(stadiumParams.Address.City) && stadium.Name.Contains(stadiumParams.Name)
            //               select new StadiumDTO
            //               {
            //                   Id = stadium.Id,
            //                   Name = stadium.Name,
            //                   Price = stadium.Price,
            //                   OwnerId = stadiumOwner.Id,
            //                   OwnerName = stadiumOwner.Name,
            //                   PhoneNumber = stadiumOwner.PhoneNumber,
            //                   Address = stadium.Address.Street,
            //                   StadiumStatus = stadium.StadiumStatus,
            //               };

            //stadiums = FindByCondition(s => s.Address.City == stadiumParams.Address.City);

            //SearchByCity(ref stadiums, stadiumParams.Address.City);

            var query = $"SELECT S.Id as Id, S.Name as Name, S.Price AS Price, S.StadiumStatus AS StadiumStatus, SO.Name AS OwerName, SO.PhoneNumber as PhoneNumber FROM Stadium AS S, StadiumOwner AS SO, Address AS A WHERE S.StadiumOwnerId = SO.Id AND S.Id = A.StadiumId AND A.City LIKE @City AND S.Name LIKE @Name";

            var parameters = new DynamicParameters();
            parameters.Add("Name", "%" + stadiumParams.Name.Trim().ToLower() + "%", DbType.String);
            parameters.Add("City", "%" + stadiumParams.Address?.City.Trim().ToLower() + "%", DbType.String);

            using (var connection = _dbContext.CreateConnection())
            {
                var stadiums = await connection.QueryAsync<StadiumDTO>(query, parameters);

                return PagedList<StadiumDTO>.ToPagedList(stadiums, stadiumParams.PageNumber, stadiumParams.PageSize);
            }
        }

        private void SearchByCity(ref IQueryable<Stadium> stadiums, string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return;

            //stadiums = stadiums.Where(s => s.Address.City.ToLower().Contains(city)).Select(stadium => new StadiumDTO
            //{
            //    Id = stadium.Id,
            //    Name = stadium.Name,
            //    Price = stadium.Price,
            //    OwnerId = stadiumOwner.Id,
            //    OwnerName = stadiumOwner.Name,
            //    PhoneNumber = stadiumOwner.PhoneNumber,
            //    Address = stadium.Address.Street,
            //    StadiumStatus = stadium.StadiumStatus,
            //});
        }

        public Task UpdateStadiumAsync(Stadium stadium)
        {
            throw new NotImplementedException();
        }
    }
}