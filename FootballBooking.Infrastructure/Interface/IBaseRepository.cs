using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        Task AddAsync(TEntity entity);

        Task AddManyAsync(IList<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateManyAsync(IList<TEntity> entities);

        Task DeleteAsync(TId id);

        Task<TEntity> GetByIdAsync(TId id);

        Task<IEnumerable<TEntity>> FindAllAsync();

        IDatabaseTransaction BeginTransaction();
    }
}