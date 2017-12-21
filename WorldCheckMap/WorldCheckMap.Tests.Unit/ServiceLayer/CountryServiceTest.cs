using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Services;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.ServiceLayer
{
    [TestClass]
    public class CountryServiceTest
    {
        [TestMethod]
        public void SmokeTest()
        {
            var repository = DataLayerMocks.GetCountryRepositoryMock();
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new CountryService(repository, mapper);
            
            var countries = service.GetCountries();
            Assert.IsNotNull(countries);
        }

        [TestMethod]
        public void EqualityTest()
        {
            var repository = DataLayerMocks.GetCountryRepositoryMock();
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new CountryService(repository, mapper);

            var countries = service.GetCountries().ToList();
            var sourceCountries = TestData.GetCountryDtos();
            
            var areSame = countries.IsEqual(sourceCountries);
            Assert.IsTrue(areSame);
        }
    }
}