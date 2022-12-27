using FootballBooking.Entities.Model;
using FootballBooking.Infrastructure.Interface;
using Moq;

namespace FootballBooking.Test.Repositories.Mock.Base
{
    public class MockBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        public static Mock<IBaseRepository<TEntity, TId>> GetMock()
        {
            var mock = new Mock<IBaseRepository<TEntity, TId>>();

            //mock.Setup(mockT => mockT.GetByIdAsync(Guid.NewGuid()))
            //   .ReturnsAsync(default(TEntity));

            return mock;
        }
    }
}