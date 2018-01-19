using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorldCheckMap.Services;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer;

namespace WorldCheckMap.Tests.Unit.ServiceLayer
{
    [TestClass]
    public class DatabaseInitializationServiceTest
    {
        [TestMethod]
        public void InitializationTest()
        {
            var initializerMock = DataLayerMocks.GetInitializerMock();
            var service = new DatabaseInitializationService(initializerMock.Object);

            service.InitializeData();

            initializerMock.Verify(init => init.InitializeDatabase(), Times.Once);
        }
    }
}