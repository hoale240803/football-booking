using AutoMapper;
using FootballBooking.Application.Interface;
using FootballBooking.Application.Services;
using FootballBooking.Infrastructure.Interface;
using FootballBooking.Mapper;
using FootballBooking.Test.Repositories.Mock;
using FootballBooking.Test.SeedData;

namespace FootballBooking.Test.Services
{
    public class StadiumServiceTest
    {
        private IStadiumRepository _stadiumRepository;
        private IWrapperRepository _wrapperRepository;
        private IStadiumService _stadiumService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _stadiumRepository = MockStadiumRepo.GetMock(StadiumData.QueryParams).Object;
            _wrapperRepository = MockWrapperRepo.GetMock().Object;
            InitMapper();
            _stadiumService = new StadiumService(_stadiumRepository, _wrapperRepository, _mapper);
        }

        private void InitMapper()
        {
            // GUIDE : https://www.thecodebuzz.com/unit-test-mock-automapper-asp-net-core-imapper/
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = configuration.CreateMapper();
            _mapper = mapper;
        }

        [Test]
        public async Task GetAvailableStadium_Return()
        {
            var avaiStadium = await _stadiumService.GetAvailableStadiumsAsync(StadiumData.QueryParams);

            Assert.NotNull(avaiStadium);
        }
    }
}