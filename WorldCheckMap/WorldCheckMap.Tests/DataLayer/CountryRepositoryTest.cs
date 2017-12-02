using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Data;
using WorldCheckMap.Data.Repositories;
using WorldCheckMap.Tests.Helpers;

namespace WorldCheckMap.Tests.DataLayer
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private void InitializeDb(WorldCheckMapContext db)
        {
            db.Countries.AddRange(DataLayerMocks.Countries);
        }

        [TestMethod]
        public void SmokeTest()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                InitializeDb(db);
                var repository = new CountryRepository(db);
                var countries = repository.GetCountries();
                Assert.IsNotNull(countries);
            }
        }

        [TestMethod]
        public void EqualityTest()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                InitializeDb(db);
                var repository = new CountryRepository(db);
                var countries = repository.GetCountries().ToList();

                var sourceCountries = DataLayerMocks.Countries;
                var areSame = countries.TrueForAll(c => sourceCountries.Find(sc => sc.Equals(c)) != null);
                Assert.IsTrue(areSame);
            }
        }
    }
}