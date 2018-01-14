using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer;
using WorldCheckMap.Tests.Unit.Infrastructure.EqualityComparison;
using WorldCheckMap.Tests.Unit.Infrastructure.Initializers;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private readonly RepositoryTestRunner _testRunner = new RepositoryTestRunner(new FullDataInitializer());

        [TestMethod]
        public void GetAccountByIdTest()
        {
            _testRunner.RunTest(db =>
            {
                var repository = new AccountRepository(db);
                var testAccount = GetAccountWithCountryStates(db);

                var accountById = repository.GetAccount(testAccount.Id);
                Assert.IsNotNull(accountById);
                var isEqualById = accountById.IsEqual(testAccount);
                Assert.IsTrue(isEqualById);

                var nonexistentId = db.Accounts.GetNonexistentId();
                var notFoundAccount = repository.GetAccount(nonexistentId);
                Assert.IsNull(notFoundAccount);
            });
        }

        [TestMethod]
        public void GetAccountByGuidTest()
        {
            _testRunner.RunTest(db =>
            {
                var repository = new AccountRepository(db);
                var testAccount = GetAccountWithCountryStates(db);

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
            _testRunner.RunTest(db =>
            {
                var repository = new AccountRepository(db);
                var newAccount = TestData.GetAccounts().First();
                newAccount.Guid = Guid.NewGuid();
                newAccount.Name += "_new";
                newAccount.CountryStates = null;

                var oldAccountsCount = db.Accounts.Count();
                var accountId = repository.AddAccount(newAccount);
                var newAccountsCount = db.Accounts.Count();
                Assert.AreEqual(oldAccountsCount + 1, newAccountsCount);

                var foundAccount = db.Accounts.Find(accountId);
                Assert.IsTrue(newAccount.IsEqual(foundAccount));
                Assert.AreEqual(foundAccount.Id, accountId);
            });
        }

        [TestMethod]
        public void AddCountryStateTest()
        {
            _testRunner.RunTest(db =>
            {
                var repository = new AccountRepository(db);
                var testAccount = GetAccountWithoutCountryStates(db);
                var testCountry = db.Countries.First();

                const CountryStatus countryStatus = CountryStatus.Been;
                var countryId = testCountry.Id;

                repository.UpdateCountryState(testAccount.Guid, countryId, countryStatus);

                var states = db.Accounts.Find(testAccount.Id).CountryStates;
                Assert.AreEqual(1, states.Count);
                Assert.AreEqual(countryId, states.First().CountryId);
                Assert.AreEqual(countryStatus, states.First().Status);
            });
        }

        [TestMethod]
        public void UpdateCountryStateTest()
        {
            _testRunner.RunTest(db =>
            {
                var repository = new AccountRepository(db);
                var testAccount = GetAccountWithCountryStates(db);
                var testState = testAccount.CountryStates.First();
                var otherStatus = Enum.GetValues(typeof(CountryStatus))
                    .Cast<CountryStatus>()
                    .First(s => s != testState.Status);

                var oldStatesCount = testAccount.CountryStates.Count;

                repository.UpdateCountryState(testAccount.Guid, testState.CountryId, otherStatus);

                var states = db.Accounts.Find(testAccount.Id).CountryStates;
                Assert.AreEqual(oldStatesCount, states.Count);

                var foundState = states.First(s => s.CountryId == testState.CountryId);
                Assert.AreEqual(otherStatus, foundState.Status);
            });
        }

        private Account GetAccountWithCountryStates(WorldCheckMapContext db) =>
            db.Accounts.Include(a => a.CountryStates).First(a => a.CountryStates != null && a.CountryStates.Any());

        private Account GetAccountWithoutCountryStates(WorldCheckMapContext db) =>
            db.Accounts.Include(a => a.CountryStates).First(a => a.CountryStates == null || !a.CountryStates.Any());
    }
}