using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.Tests.Unit.Helpers;
using WorldCheckMap.Tests.Unit.Helpers.EqualityComparison;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private void InitializeDb(WorldCheckMapContext db)
        {
            db.Accounts.AddRange(TestData.Accounts);
            db.SaveChanges();
        }

        [TestMethod]
        public void GetAccountTest()
        {
            using (var db = DbContextBuilder.GetContext())
            {
                InitializeDb(db);
                var repository = new AccountRepository(db);

                var accountByGuid = repository.GetAccount(TestData.Accounts[0].Guid);

                Assert.IsNotNull(accountByGuid);
                var isEqualByGuid = accountByGuid.IsEqual(TestData.Accounts[0]);
                Assert.IsTrue(isEqualByGuid);

                var accoutById = repository.GetAccount(TestData.Accounts[1].Id);
                Assert.IsNotNull(accoutById);
                var isEqualById = accoutById.IsEqual(TestData.Accounts[1]);
                Assert.IsTrue(isEqualById);
            }
        }
    }
}