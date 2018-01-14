using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Infrastructure.Initializers
{
    internal class CountriesInitializer : BaseDbInitializer
    {
        protected override void PopulateDbWithData(WorldCheckMapContext db)
        {
            var countries = TestData.GetCountries();
            db.Countries.AddRange(countries);
        }
    }
}