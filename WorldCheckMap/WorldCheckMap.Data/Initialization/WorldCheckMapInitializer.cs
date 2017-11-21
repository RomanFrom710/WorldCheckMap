using System.Data.Entity;

namespace WorldCheckMap.Data.Initialization
{
    internal class WorldCheckMapInitializer : CreateDatabaseIfNotExists<WorldCheckMapContext>
    {
        protected override void Seed(WorldCheckMapContext context)
        {
            var countries = CountriesParser.GetCountries();
            context.Countries.AddRange(countries);
            context.SaveChanges();
        }
    }
}
