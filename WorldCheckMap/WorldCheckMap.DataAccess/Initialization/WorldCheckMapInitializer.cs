using WorldCheckMap.DataAccess.Initialization.Interfaces;

namespace WorldCheckMap.DataAccess.Initialization
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

        public void InitializeDatabase()
        {
            if (!_context.Database.EnsureCreated())
            {
                return;
            }

            var countries = _storage.GetCountries();
            _context.Countries.AddRange(countries);
            _context.SaveChanges();
        }
    }
}
