using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace FootballBooking.Application.Services
{
    public class BaseService<T> : IBaseRepository<T>, IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task AddAsync(T entity)
        {
            await _baseRepository.AddAsync(entity);
        }

        public async Task AddManyAsync(IList<T> entities)
        {
            await _baseRepository.AddManyAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(IList<Guid> ids)
        {
            await _baseRepository.DeleteManyAsync(ids);
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(QueryParams queryParams)
        {
            return await _baseRepository
                .FindAll()
                .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                .Take(queryParams.PageSize)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _baseRepository.UpdateAsync(entity);
        }

        public async Task UpdateManyAsync(IList<T> entities)
        {
            await _baseRepository.UpdateManyAsync(entities);
        }
    }
}