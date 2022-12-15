using FootballBooking.Entities.DTOs;

namespace FootballBooking.Application.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task AddAsync(T entity);

        Task AddManyAsync(IList<T> entities);

        Task DeleteAsync(Guid id);

        Task DeleteManyAsync(IList<Guid> id);

        Task<IEnumerable<T>> GetAllAsync(QueryParams queryParams);

        Task UpdateAsync(T entity);

        Task UpdateManyAsync(IList<T> ids);

        Task<T> GetByIdAsync(Guid id);
    }
}