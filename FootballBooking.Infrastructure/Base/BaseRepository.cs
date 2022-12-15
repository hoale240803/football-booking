using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace FootballBooking.Infrastructure.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly FootballBookingDbContext _footballBookingContext;

        public BaseRepository(FootballBookingDbContext footballBookingContext)
        {
            _footballBookingContext = footballBookingContext;
        }

        public async Task AddAsync(T entity)
        {
            await _footballBookingContext.Set<T>().AddAsync(entity);
            await _footballBookingContext.SaveChangesAsync();
        }

        public async Task AddManyAsync(IList<T> entities)
        {
            await _footballBookingContext.Set<T>().AddRangeAsync(entities);
            await _footballBookingContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var deletedEntity = await _footballBookingContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            if (deletedEntity != null)
                _footballBookingContext.Remove(deletedEntity);

            await _footballBookingContext.SaveChangesAsync();
        }

        /// <summary>
        /// Handle with small size of list
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task DeleteManyAsync(IList<Guid> ids)
        {
            var deletedEntities = _footballBookingContext.Set<T>().Where(x => ids.Contains(x.Id)).ToList();
            if (deletedEntities.Any())
            {
                _footballBookingContext.Set<T>().RemoveRange(deletedEntities);
                await _footballBookingContext.SaveChangesAsync();
            }
        }

        public IQueryable<T> FindAll()
        {
            return _footballBookingContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _footballBookingContext.Set<T>().SingleAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _footballBookingContext.Set<T>().Update(entity);
            await _footballBookingContext.SaveChangesAsync();
        }

        public Task UpdateManyAsync(IList<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}