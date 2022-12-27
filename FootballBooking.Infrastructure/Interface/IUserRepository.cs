using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
    }
}