using AutoMapper;
using FootballBooking.Application.Exceptions;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Entities.Resources;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Application.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public StadiumService(IStadiumRepository stadiumRepository,
            IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _stadiumRepository = stadiumRepository;
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }

        public async Task CreateStadiumAsync(Stadium stadium)
        {
            // 1. TODO: Validate Stadium
            await ValidateStadiumAsync(stadium);

            //ValidateAddress(stadium.Address);

            using var transaction = _wrapperRepository.BeginTransaction();
            try
            {
                // 2. Todo: Insert Stadium

                stadium.StadiumOwnerId = Guid.Parse("F71F52DB-9007-4F78-9D89-04A53F51B761");
                stadium.Id = Guid.NewGuid();
                await _wrapperRepository.Stadium.AddAsync(stadium);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
        }

        private void ValidateAddress(Address address)
        {
        }

        private async Task ValidateStadiumAsync(Stadium stadium)
        {
            // 1. TODO Check existed name
            if (await _stadiumRepository.IsExistingStadiumNameAsync(stadium.Name))
                throw new AppException(ErrorMessages.StadiumWasExisted);

            // 2. validate price
        }

        public async Task<IList<StadiumRes>> GetAvailableStadiumsAsync(QueryParams queryParams)
        {
            var temp = await _stadiumRepository.GetAvailableStadiumsAsync(queryParams);
            return temp;
        }

        public async Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams)
        {
            return await _stadiumRepository.GetStadiumsAsync(stadiumParams);
        }

        public async Task AddStadiumAsync(Stadium stadium)
        {
            await _stadiumRepository.AddAsync(stadium);
        }

        public async Task<StadiumDTO> GetStadiumByIdAsync(Guid id)
        {
            var result = _mapper.Map<StadiumDTO>(await _stadiumRepository.GetByIdAsync(id));

            return result;
        }

        public async Task UpdateStadiumAsync(Stadium stadium)
        {
            await _stadiumRepository.UpdateAsync(stadium);
        }

        public async Task DeleteStadiumAsync(Guid id)
        {
            await _stadiumRepository.DeleteAsync(id);
        }
    }
}