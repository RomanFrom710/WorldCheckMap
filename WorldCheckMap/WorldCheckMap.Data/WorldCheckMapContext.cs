using Microsoft.EntityFrameworkCore;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data
{
    public class WorldCheckMapContext : DbContext
    {
        public WorldCheckMapContext() { }

        public WorldCheckMapContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryState> CountryStates { get; set; }
    }
}
