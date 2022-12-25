using FootballBooking.Entities.DTOs;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Test.SeedData;
using Moq;

namespace FootballBooking.Test.Repositories.Mock
{
    public class MockWrapperRepo
    {
        public static Mock<IWrapperRepository> GetMock()
        {
         
            var stadiumRepoMock = MockStadiumRepo.GetMock(StadiumData.QueryParams);
            var wrapperRepo = new Mock<IWrapperRepository>();

            wrapperRepo.Setup(wrapper => wrapper.Stadium).Returns(stadiumRepoMock.Object);
            return wrapperRepo;
        }
    }
}