using System.Threading.Tasks;
using WorldCheckMap.Data.Initialization.Interfaces;

namespace WorldCheckMap.Data.Initialization
{
    public class WorldCheckMapInitializer : IWorldCheckMapInitializer
    {
        private readonly WorldCheckMapContext _context;
        private readonly ICountriesStorage _storage;

        public WorldCheckMapInitializer(WorldCheckMapContext context, ICountriesStorage storage)
        {
            _context = context;
            _storage = storage;
        }

        public async Task InitializeDatabaseAsync()
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var countries = _storage.GetCountries();
                _context.Countries.AddRange(countries);
                await _context.SaveChangesAsync();
            }
        }
    }
}
