using Microsoft.EntityFrameworkCore;
using WorldCheckMap.DataAccess.Models;

namespace WorldCheckMap.DataAccess
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
