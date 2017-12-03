using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Data.Initialization;
using WorldCheckMap.Data.Models;
using WorldCheckMap.Tests.Helpers;
using WorldCheckMap.Tests.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.DataLayer
{
    [TestClass]
    public class DatabaseInitializerTest
    {
        private async Task<List<Country>> GetCountriesFromInitializer()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                var storage = DataLayerMocks.GetCountryStorageMock();
                var initializer = new WorldCheckMapInitializer(db, storage);
                await initializer.InitializeDatabaseAsync();

                var countries = await db.Countries.ToListAsync();
                return countries;
            }
        }

        [TestMethod]
        public async Task SmokeTest()
        {
            var countries = await GetCountriesFromInitializer();
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Count > 0);
        }

        [TestMethod]
        public async Task EqualityTest()
        {
            var countries = await GetCountriesFromInitializer();
            var sourceCountries = TestData.Countries;

            var areSame = countries.IsEqual(sourceCountries);
            Assert.IsTrue(areSame);
        }
    }
}