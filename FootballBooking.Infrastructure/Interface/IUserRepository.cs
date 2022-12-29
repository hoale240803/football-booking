using FootballBooking.Entities.Model;

namespace FootballBooking.Infrastructure.Interface
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {

        Task<User> GetByUserNameAsync(string userName);
        Task<bool> IsExistingUserName(string userName);
    }
}