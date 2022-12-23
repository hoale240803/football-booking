using FootballBooking.Application.Interface;
using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;

namespace FootballBooking.Application.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(IBaseRepository<Address> baseRepository) : base(baseRepository)
        {
        }
    }
}