using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private List<Account> InitializeDb(WorldCheckMapContext db)
        {
            var testAccounts = TestData.GetAccounts();
            db.Accounts.AddRange(testAccounts);
            db.SaveChanges();
            return testAccounts;
        }

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
    }
}