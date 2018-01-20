using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.Services;
using WorldCheckMap.Tests.Common;
using WorldCheckMap.Tests.Unit.Infrastructure.ServiceLayer;

namespace WorldCheckMap.Tests.Unit.ServiceLayer
{
    [TestClass]
    public class CoreDataServiceTest
    {
        [TestMethod]
        public void CoreDataTest()
        {
            var countryService = ServiceLayerMocks.GetCountryServiceMock();
            var coreDataService = new CoreDataService(countryService);
            var testCountries = TestData.GetCountryDtos();

            var coreData = coreDataService.GetClientInitData();
            Assert.IsTrue(coreData.Countries.IsEqual(testCountries));

            var statusNames = Enum.GetNames(typeof(CountryStatus));
            Assert.IsTrue(statusNames.IsEqual(coreData.CountryStatuses));
        }
    }
}