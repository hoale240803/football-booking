using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);

        Task AddManyAsync(IList<T> entities);

        Task UpdateAsync(T entity);

        Task UpdateManyAsync(IList<T> entities);

        Task DeleteAsync(Guid id);

        Task DeleteManyAsync(IList<Guid> ids);

        Task<T> GetByIdAsync(Guid id);

        IQueryable<T> FindAll();

        IDatabaseTransaction BeginTransaction();
    }
}