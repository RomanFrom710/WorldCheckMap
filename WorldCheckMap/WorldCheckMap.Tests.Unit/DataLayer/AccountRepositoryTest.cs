using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.DataLayer;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private readonly RepositoryTestRunner<AccountRepository> _testRunner =
            new RepositoryTestRunner<AccountRepository>(db => new AccountRepository(db));

        [TestMethod]
        public void GetAccountByIdTest()
        {
            var testAccount = TestData.GetAccounts().First();
            _testRunner.RunTest(db =>
            {
                db.Accounts.Add(testAccount);
            }, (db, repository) =>
            {
                var accountById = repository.GetAccount(testAccount.Id);
                Assert.IsNotNull(accountById);
                var isEqualById = accountById.IsEqual(testAccount);
                Assert.IsTrue(isEqualById);

                var notFoundAccount = repository.GetAccount(testAccount.Id + 1);
                Assert.IsNull(notFoundAccount);
            });
        }

        [TestMethod]
        public void GetAccountByGuidTest()
        {
            var testAccount = TestData.GetAccounts().First();
            _testRunner.RunTest(db =>
            {
                db.Accounts.Add(testAccount);
            }, (db, repository) =>
            {
                var accountByGuid = repository.GetAccount(testAccount.Guid);
                Assert.IsNotNull(accountByGuid);
                var isEqualByGuid = accountByGuid.IsEqual(testAccount);
                Assert.IsTrue(isEqualByGuid);

                var notFoundAccount = repository.GetAccount(Guid.NewGuid());
                Assert.IsNull(notFoundAccount);
            });
        }

        [TestMethod]
        public void AddAccountTest()
        {
            var testAccount = TestData.GetAccounts().First();
            _testRunner.RunTest(db => { }, (db, repository) =>
            {
                var accountId = repository.AddAccount(testAccount);
                var dbAccounts = db.Accounts.ToList();
                Assert.AreEqual(1, dbAccounts.Count);

                var foundAccount = dbAccounts.First();
                Assert.IsTrue(testAccount.IsEqual(foundAccount));

                Assert.AreEqual(foundAccount.Id, accountId);
            });
        }

        [TestMethod]
        public void AddCountryStateTest()
        {
            var testCountry = TestData.GetCountries().First();
            var testAccount = TestData.GetAccounts().First();
            testAccount.CountryStates = null;

            _testRunner.RunTest(db =>
            {
                db.Accounts.Add(testAccount);
            }, (db, repository) =>
            {
                var countryState = new CountryState
                {
                    CountryId = testCountry.Id,
                    AccountId = testAccount.Id,
                    Status = CountryStatus.Been
                };

                repository.UpsertCountryState(testAccount.Guid, countryState);

                var states = db.Accounts.Find(testAccount.Id).CountryStates;
                Assert.AreEqual(1, states.Count);
                Assert.AreEqual(countryState.CountryId, states.First().CountryId);
                Assert.AreEqual(countryState.Status, states.First().Status);
            });
        }

        [TestMethod]
        public void UpdateCountryStateTest()
        {
            var testAccount = TestData.GetAccounts().First();
            var testState = testAccount.CountryStates.First();
            var otherStatus = Enum.GetValues(typeof(CountryStatus)).Cast<CountryStatus>()
                .First(s => s != testState.Status);

            _testRunner.RunTest(db =>
            {
                db.Accounts.Add(testAccount);
            }, (db, repository) =>
            {
                var oldStatesCount = testAccount.CountryStates.Count;

                var countryState = new CountryState
                {
                    CountryId = testState.CountryId,
                    AccountId = testAccount.Id,
                    Status = otherStatus
                };

                repository.UpsertCountryState(testAccount.Guid, countryState);

                var states = db.Accounts.Find(testAccount.Id).CountryStates;
                Assert.AreEqual(oldStatesCount, states.Count);

                var foundState = states.First(s => s.CountryId == testState.CountryId);
                Assert.AreEqual(otherStatus, foundState.Status);
            });
        }
    }
}