using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class AccountRepositoryTest
    {
        [TestMethod]
        public void GetAccountTest()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                var testAccounts = InitializeDb(db);
                var repository = new AccountRepository(db);

                var accountByGuid = repository.GetAccount(testAccounts[0].Guid);

                Assert.IsNotNull(accountByGuid);
                var isEqualByGuid = accountByGuid.IsEqual(testAccounts[0]);
                Assert.IsTrue(isEqualByGuid);

                var accoutById = repository.GetAccount(testAccounts[1].Id);
                Assert.IsNotNull(accoutById);
                var isEqualById = accoutById.IsEqual(testAccounts[1]);
                Assert.IsTrue(isEqualById);
            }
        }

        [TestMethod]
        public void AddAccountTest()
        {
            var testAccounts = TestData.GetAccounts();
            using (var db = DbContextBuilder.GetContext())
            {
                var repository = new AccountRepository(db);

                var account = testAccounts[0];
                var accountId = repository.AddAccount(account);

                var dbAccounts = db.Accounts.ToList();
                Assert.AreEqual(dbAccounts.Count, 1);

                var foundAccount = dbAccounts.First();
                Assert.IsTrue(account.IsEqual(foundAccount));

                Assert.AreEqual(accountId, foundAccount.Id);
            }
        }

        [TestMethod]
        public void AddCountryStateTest()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                var repository = new AccountRepository(db);

                var testAccount = InitializeDbWithoutCountyStates(db)[0];
                var testCountries = TestData.GetCountries();

                var countryState = new CountryState
                {
                    CountryId = testCountries[0].Id,
                    AccountId = testAccount.Id,
                    Status = CountryStatus.Been
                };

                repository.UpsertCountryState(testAccount.Guid, countryState);

                var states = db.Accounts.Find(testAccount.Id).States;
                Assert.AreEqual(states.Count, 1);
                Assert.AreEqual(states.First().Status, countryState.Status);
            }
        }

        [TestMethod]
        public void UpdateCountryStateTest()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                var repository = new AccountRepository(db);

                var testAccount = InitializeDb(db)[0];
                var testState = testAccount.States.First();

                var otherStatus = Enum.GetValues(typeof(CountryStatus)).Cast<CountryStatus>()
                    .First(s => s != testState.Status);

                var oldStatesCount = testAccount.States.Count;

                var countryState = new CountryState
                {
                    CountryId = testState.CountryId,
                    AccountId = testAccount.Id,
                    Status = otherStatus
                };

                repository.UpsertCountryState(testAccount.Guid, countryState);

                var states = db.Accounts.Find(testAccount.Id).States;
                Assert.AreEqual(states.Count, oldStatesCount);

                var foundState = states.First(s => s.CountryId == testState.CountryId);
                Assert.AreEqual(foundState.Status, otherStatus);
            }
        }

        private List<Account> InitializeDb(WorldCheckMapContext db)
        {
            var testAccounts = TestData.GetAccounts();
            db.Accounts.AddRange(testAccounts);
            db.SaveChanges();
            return testAccounts;
        }

        private List<Account> InitializeDbWithoutCountyStates(WorldCheckMapContext db)
        {
            var testAccounts = TestData.GetAccounts().Select(a =>
            {
                a.States = null;
                return a;
            }).ToList();
            db.Accounts.AddRange(testAccounts);
            db.SaveChanges();
            return testAccounts;
        }
    }
}