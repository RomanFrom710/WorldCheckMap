using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Data.Repositories;
using WorldCheckMap.Services;
using WorldCheckMap.Tests.Helpers;

namespace WorldCheckMap.Tests.ServiceLayer
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
            var sourceCountries = DataLayerMocks.Countries;

            Assert.IsNotNull(countries);
            var areSame = countries.TrueForAll(c => sourceCountries.Find(sc => sc.Id == c.Id) != null);
            Assert.IsTrue(areSame);
        }
    }
}