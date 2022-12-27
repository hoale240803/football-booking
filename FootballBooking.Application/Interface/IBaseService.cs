//using FootballBooking.Entities.DTOs;
//using FootballBooking.Entities.Model;

//namespace FootballBooking.Application.Interface
//{
//    public interface IBaseService<TEntity, TId> where TEntity : BaseEntity<TId>
//    {
//        Task AddAsync(TEntity entity);

//        Task AddManyAsync(IList<TEntity> entities);

//        Task DeleteAsync(TId id);


//        Task<IEnumerable<TEntity>> GetAllAsync(QueryParams queryParams);

//        Task UpdateAsync(TEntity entity);

//        Task UpdateManyAsync(IList<TEntity> ids);

//        Task<TEntity> GetByIdAsync(TId id);
//    }
//}