using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer;
using WorldCheckMap.Tests.Unit.Infrastructure.EqualityComparison;
using WorldCheckMap.Tests.Unit.Infrastructure.Initializers;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private readonly RepositoryTestRunner _testRunner = new RepositoryTestRunner(new CountriesInitializer());

        [TestMethod]
        public void SmokeTest()
        {
            _testRunner.RunTest(db =>
            {
                var repository = new CountryRepository(db);
                var countries = repository.GetCountries();
                Assert.IsNotNull(countries);
            });
        }

        [TestMethod]
        public void EqualityTest()
        {
            _testRunner.RunTest(db =>
            {
                var repository = new CountryRepository(db);
                var dbCountries = db.Countries.ToList();
                var repositoryCountries = repository.GetCountries();
                Assert.IsTrue(dbCountries.IsEqual(repositoryCountries));
            });
        }
    }
}