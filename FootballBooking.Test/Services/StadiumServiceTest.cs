using FootballBooking.Application.Interface;
using FootballBooking.Application.Services;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Test.Repositories.Mock;
using FootballBooking.Test.SeedData;

namespace FootballBooking.Test.Services
{
    public class StadiumServiceTest
    {
        private IStadiumRepository _stadiumRepository;
        private IWrapperRepository _wrapperRepository;
        private IStadiumService _stadiumService;

        [SetUp]
        public void Setup()
        {
            _stadiumRepository = MockStadiumRepo.GetMock(StadiumData.QueryParams).Object;
            _wrapperRepository = MockWrapperRepo.GetMock().Object;
            _stadiumService = new StadiumService(_stadiumRepository, _wrapperRepository);
        }

        [Test]
        public async Task GetAvailableStadium_Return()
        {
            var avaiStadium = await _stadiumService.GetAvailableStadiumsAsync(StadiumData.QueryParams);

            Assert.NotNull(avaiStadium);
        }
    }
}