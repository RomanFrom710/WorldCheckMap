using System.Data.Entity;
using WorldCheckMap.Data.Initialization;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data
{
    public class WorldCheckMapContext : DbContext
    {
        public WorldCheckMapContext()
        {
            Database.SetInitializer(new WorldCheckMapInitializer());
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryState> CountryStates { get; set; }
    }
}
