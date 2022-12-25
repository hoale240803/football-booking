using FootballBooking.Infrastructure.Interface;
using FootballBooking.Test.Repositories.Mock;
using FootballBooking.Test.SeedData;

namespace FootballBooking.Test.Repositories
{
    public class StadiumRepositoryTest
    {
        private IStadiumRepository _stadiumRepository;
        private IWrapperRepository _wrapperRepository;

        [SetUp]
        public void Setup()
        {
            _stadiumRepository = MockStadiumRepo.GetMock(StadiumData.QueryParams).Object;

            _stadiumRepository = MockStadiumRepo.GetMock(StadiumData.QueryParams).Object;
        }

        [Test]
        public async Task Test111()
        {
            //  var availableStadium = await wrapperRepoMock.Object.Stadium.GetAvailableStadiumsAsync(StadiumData.QueryParams);
            var availableStadium1 = await _stadiumRepository.GetAvailableStadiumsAsync(StadiumData.QueryParams);
            //var availableStadium1 = await wrapperMock.Object.Stadium.GetAvailableStadiumsAsync(queryParam);

            //Assert.NotNull(availableStadium);
        }
    }
}