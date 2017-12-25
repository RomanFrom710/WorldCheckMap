using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.DataLayer;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private readonly RepositoryTestRunner<CountryRepository> _testRunner =
            new RepositoryTestRunner<CountryRepository>(db => new CountryRepository(db));

        [TestMethod]
        public void SmokeTest()
        {
            var testCountries = TestData.GetCountries();
            _testRunner.RunTest(db =>
            {
                db.Countries.AddRange(testCountries);
            }, (db, repository) => {
                var countries = repository.GetCountries();
                Assert.IsNotNull(countries);
            });
        }

        [TestMethod]
        public void EqualityTest()
        {
            var testCountries = TestData.GetCountries();
            _testRunner.RunTest(db =>
            {
                db.Countries.AddRange(testCountries);
            }, (db, repository) => {
                var countries = repository.GetCountries().ToList();
                var areSame = countries.IsEqual(testCountries);
                Assert.IsTrue(areSame);
            });
        }
    }
}