using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Infrastructure.Interface;
using Moq;

namespace FootballBooking.Test.Repositories.Mock
{
    public class MockStadiumRepo
    {
        public static Mock<IStadiumRepository> GetMock(QueryParams queryParams)
        {
            var mock = new Mock<IStadiumRepository>();

            var availableStadiums = new List<StadiumRes>
            {
                new StadiumRes
                {
                    Address ="dsf",
                    Name = "Cau Hoa Xuan"
                },

                new StadiumRes
                {
                    Address ="dsf",
                    Name = "Cau Hoa Xuan"
                }
            };

            mock.Setup(mockStadium => mockStadium.GetAvailableStadiumsAsync(queryParams))
                .ReturnsAsync(availableStadiums);

            return mock;
        }
    }
}