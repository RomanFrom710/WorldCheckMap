using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.DataAccess.Repositories.Interfaces;

namespace WorldCheckMap.DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly WorldCheckMapContext _context;

        public CountryRepository(WorldCheckMapContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Country> GetCountries()
        {
            return _context.Countries.ToList();
        }
    }
}
