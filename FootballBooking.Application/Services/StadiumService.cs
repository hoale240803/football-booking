using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Application.Services
{
    public class StadiumService : BaseService<Stadium>, IStadiumService
    {
        private readonly IStadiumRepository _stadiumRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IWrapperRepository _wrapperRepository;

        public StadiumService(IBaseRepository<Stadium> baseRepository, IStadiumRepository stadiumRepository,
            IAddressRepository addressRepository, IWrapperRepository wrapperRepository) : base(baseRepository)
        {
            _stadiumRepository = stadiumRepository;
            _addressRepository = addressRepository;
            _wrapperRepository = wrapperRepository;
        }

        public async Task CreateStadiumAsync(Stadium stadium)
        {
            // 1. TODO: Validate Stadium
            ValidateStadium(stadium);

            ValidateAddress(stadium.Address);

            using (var transaction = _wrapperRepository.BeginTransaction())
            {
                try
                {
                    // 2. TODO: Insert Address
                    //await _addressRepository.AddAsync(stadium.Address);
                    var task1 = _wrapperRepository.Address.AddAsync(stadium.Address);

                    // 3. TODO: Insert Stadium
                    //await _stadiumRepository.AddAsync(stadium);
                    var task2 = _wrapperRepository.Stadium.AddAsync(stadium);

                    Task.WaitAll(task1, task2);
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {

                    await transaction.RollbackAsync();
                }
            }
        }

        private void ValidateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        private void ValidateStadium(Stadium stadium)
        {
            // 1. TODO Check existed name
            var stadiumName = _stadiumRepository.IsExistingStadiumNameAsync(stadium.Name)
                ?? throw new ApplicationException($"Stadium {stadium.Name} was existed ");

            // 2. validate price
        }

        public async Task<IList<StadiumDTO>> GetAvailableStadiumsAsync(QueryParams queryParams)
        {
            return await _stadiumRepository.GetAvailableStadiumsAsync(queryParams);
        }

        public async Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams)
        {
            return await _stadiumRepository.GetStadiumsAsync(stadiumParams);
        }
    }
}