using FootballBooking.Entities.DTOs;
using FootballBooking.Entities.DTOs.Res;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.UnitTest.SeedData;
using Moq;

namespace FootballBooking.UnitTest.RepositoryTest
{
    [TestClass]
    public class StadiumRepositoryTest
    {
        private IWrapperRepository _unitOfWork;

        public StadiumRepositoryTest(IWrapperRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Initialize();
        }

        public void Initialize()
        {
            var _unitOfWorkMock = new Mock<IWrapperRepository>();

            InitStadiumRepo(_unitOfWorkMock);
        }

        private static void InitStadiumRepo(Mock<IWrapperRepository> _unitOfWorkMock)
        {
            var queryParams = new QueryParams
            {
                PageNumber = 1,
                PageSize = 10,
            };

            var result = new List<StadiumRes>
            {
                new StadiumRes
                {
                     Id = Guid.NewGuid(),
                     Name= StadiumData.Name,
                     OwnerId= Guid.NewGuid(),
                     OwnerName = StadiumData.OwnerName
                },
                new StadiumRes
                {
                     Id = Guid.NewGuid(),
                     Name= StadiumData.Name,
                     OwnerId= Guid.NewGuid(),
                     OwnerName = StadiumData.OwnerName
                },
            };

            _unitOfWorkMock.Setup(x => x.Stadium.GetAvailableStadiumsAsync(queryParams)).ReturnsAsync(result);
        }

        [TestMethod]
        public async Task GetAvailableStadium_Return_NotNull()
        {
            var queryParam = new QueryParams
            {
                PageSize = 10,
                PageNumber = 1
            };

            var result = await _unitOfWork.Stadium.GetAvailableStadiumsAsync(queryParam);

            var expectedResult = new List<StadiumRes>
            {
                new StadiumRes {
                    Address = "address",
                    Name= "Ale goal",
                    OwnerName = "Ale goal owner",
                    PhoneNumber = "0334517232",
                    Price = 123
                },
                new StadiumRes {
                    Address = "address",
                    Name= "Ale goal",
                    OwnerName = "Ale goal owner",
                    PhoneNumber = "0334517232",
                    Price = 123
                },
            };

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult);
        }
    }
}