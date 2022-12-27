﻿using FootballBooking.Entities;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Infrastructure.Repository
{
    public class AddressRepository : BaseRepository<Address, Guid>, IAddressRepository
    {
        public AddressRepository(FootballBookingDbContext footballBookingContext) : base(footballBookingContext)
        {
        }
    }
}