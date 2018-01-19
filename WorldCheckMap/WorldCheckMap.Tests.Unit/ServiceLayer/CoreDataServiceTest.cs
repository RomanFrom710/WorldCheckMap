using System;
using System.Linq;
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
            Assert.IsTrue(Enum.GetNames(typeof(CountryStatus)).IsEqual(coreData.CountryStatusValues.Keys));
            Assert.IsTrue(Enum.GetValues(typeof(CountryStatus)).Cast<int>().IsEqual(coreData.CountryStatusValues.Values));
        }
    }
}