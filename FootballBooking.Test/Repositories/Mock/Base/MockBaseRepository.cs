using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Moq;

namespace FootballBooking.Test.Repositories.Mock.Base
{
    public class MockBaseRepository<T> where T : BaseEntity
    {
        public static Mock<IBaseRepository<T>> GetMock()
        {
            var mock = new Mock<IBaseRepository<T>>();

            mock.Setup(mockT => mockT.GetByIdAsync(Guid.NewGuid()))
               .ReturnsAsync(default(T));

            return mock;
        }
    }
}