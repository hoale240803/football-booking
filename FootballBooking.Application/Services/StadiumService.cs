﻿using FootballBooking.Application.Exceptions;
using FootballBooking.Application.Interface;
using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Entities.Helpers;
using FootballBooking.Entities.Model;
using FootballBooking.Entities.Resources;
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
            await ValidateStadiumAsync(stadium);

            ValidateAddress(stadium.Address);

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
            return await _stadiumRepository.GetAvailableStadiumsAsync(queryParams);
        }

        public async Task<PagedList<StadiumDTO>> GetStadiumsAsync(StadiumParams stadiumParams)
        {
            return await _stadiumRepository.GetStadiumsAsync(stadiumParams);
        }
    }
}