using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FootballBooking.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        public readonly FootballBookingDbContext _footballBookingContext;

        public BaseRepository(FootballBookingDbContext footballBookingContext)
        {
            _footballBookingContext = footballBookingContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _footballBookingContext.Set<TEntity>().AddAsync(entity);
            await _footballBookingContext.SaveChangesAsync();
        }

        public async Task AddManyAsync(IList<TEntity> entities)
        {
            await _footballBookingContext.Set<TEntity>().AddRangeAsync(entities);
            await _footballBookingContext.SaveChangesAsync();
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(_footballBookingContext);
        }

        public async Task DeleteAsync(TEntity deletedEntity)
        {
            _footballBookingContext.Remove(deletedEntity);
            await _footballBookingContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            var queryable = _footballBookingContext.Set<TEntity>().AsQueryable();
            if (specification == null) return Task.FromResult(queryable.AsNoTracking().AsEnumerable());

            var queryableWithInclude = specification.Includes
                .Aggregate(queryable, (current, include) => current.Include(include));

            var result = queryableWithInclude
                .Where(specification.Expression)
                .AsNoTracking()
                .AsEnumerable();

            return Task.FromResult(result);
        }

        public Task<IEnumerable<TEntity>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _footballBookingContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(TEntity id)
        {
            return await _footballBookingContext.Set<TEntity>().SingleAsync(x => x.Id.Equals(id));
        }

        public Task<TEntity> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _footballBookingContext.Set<TEntity>().Update(entity);
            await _footballBookingContext.SaveChangesAsync();
        }

        public Task UpdateManyAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}