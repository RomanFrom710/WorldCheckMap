﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private void InitializeDb(WorldCheckMapContext db)
        {
            db.Countries.AddRange(TestData.GetCountries());
            db.SaveChanges();
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
                var sourceCountries = TestData.GetCountries();

                var areSame = countries.IsEqual(sourceCountries);
                Assert.IsTrue(areSame);
            }
        }
    }
}