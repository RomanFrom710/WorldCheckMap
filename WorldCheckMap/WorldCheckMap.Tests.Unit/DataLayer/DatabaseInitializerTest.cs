using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Initialization;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class DatabaseInitializerTest
    {
        private List<Country> GetCountriesFromInitializer()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                var storage = DataLayerMocks.GetCountryStorageMock();
                var initializer = new WorldCheckMapInitializer(db, storage);
                initializer.InitializeDatabase();

                var countries = db.Countries.ToList();
                return countries;
            }
        }

        [TestMethod]
        public void SmokeTest()
        {
            var countries = GetCountriesFromInitializer();
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Count > 0);
        }

        [TestMethod]
        public void EqualityTest()
        {
            var countries = GetCountriesFromInitializer();
            var sourceCountries = TestData.GetCountries();

            var areSame = countries.IsEqual(sourceCountries);
            Assert.IsTrue(areSame);
        }
    }
}