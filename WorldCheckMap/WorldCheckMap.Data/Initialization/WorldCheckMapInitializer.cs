using System.Collections.Generic;
using System.Data.Entity;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data.Initialization
{
    internal class WorldCheckMapInitializer : CreateDatabaseIfNotExists<WorldCheckMapContext>
    {
        protected override void Seed(WorldCheckMapContext context)
        {
            context.Countries.AddRange(new List<Country>
            {

            });
        }
    }
}
