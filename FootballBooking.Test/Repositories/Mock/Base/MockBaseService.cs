//using FootballBooking.Application.Interface;
//using FootballBooking.Entities.Model;
//using FootballBooking.Test.SeedData;
//using Moq;

//namespace FootballBooking.Test.Repositories.Mock.Base
//{
//    public class MockBaseService<T> where T: BaseEntity
//    {
//        public static Mock<IBaseService<T>> GetMock()
//        {
//            var mock = new Mock<IBaseService<T>>();

//            mock.Setup(mockT => mockT.GetAllAsync(StadiumData.QueryParams))
//                .ReturnsAsync(new List<T>());

//            return mock;
//        }
//    }
//}