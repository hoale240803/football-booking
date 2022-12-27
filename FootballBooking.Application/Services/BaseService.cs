//using FootballBooking.Application.Interface;
//using FootballBooking.Entities.DTOs;
//using FootballBooking.Infrastructure.Interface;
//using Microsoft.EntityFrameworkCore;

//namespace FootballBooking.Application.Services
//{
//    public class BaseService : IBaseService<TEntity, TId>
//    {
//        private readonly IBaseRepository<TEntity, TId> _baseRepository;

//        public BaseService(IBaseRepository<TEntity, TId> baseRepository)
//        {
//            _baseRepository = baseRepository;
//        }

//        public async Task AddAsync(TEntity entity)
//        {
//            await _baseRepository.AddAsync(entity);
//        }

//        public async Task AddManyAsync(IList<TEntity> entities)
//        {
//            await _baseRepository.AddManyAsync(entities);
//        }

//        public async Task DeleteAsync(TId id)
//        {
//            await _baseRepository.DeleteAsync(id);
//        }

//        public IQueryable<TEntity> FindAll()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IEnumerable<TEntity>> GetAllAsync(QueryParams queryParams)
//        {
//            return await _baseRepository
//                .FindAll()
//                .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
//                .Take(queryParams.PageSize)
//                .ToListAsync();
//        }

//        public async Task<TEntity> GetByIdAsync(TId id)
//        {
//            return await _baseRepository.GetByIdAsync(id);
//        }

//        public async Task UpdateAsync(TEntity entity)
//        {
//            await _baseRepository.UpdateAsync(entity);
//        }

//        public async Task UpdateManyAsync(IList<TEntity> entities)
//        {
//            await _baseRepository.UpdateManyAsync(entities);
//        }
//    }
//}