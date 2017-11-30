using Microsoft.EntityFrameworkCore;
using WorldCheckMap.Data.Initialization;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data
{
    public class WorldCheckMapContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryState> CountryStates { get; set; }
    }
}
