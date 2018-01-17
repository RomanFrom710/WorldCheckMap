using WorldCheckMap.DataAccess;
using WorldCheckMap.Tests.Common;

namespace WorldCheckMap.Tests.Unit.Infrastructure.Initializers
{
    public class FullDataInitializer : BaseDbInitializer
    {
        protected override void PopulateDbWithData(WorldCheckMapContext db)
        {
            var countries = TestData.GetCountries();
            var accounts = TestData.GetAccounts();

            db.Countries.AddRange(countries);
            db.Accounts.AddRange(accounts);
        }
    }
}