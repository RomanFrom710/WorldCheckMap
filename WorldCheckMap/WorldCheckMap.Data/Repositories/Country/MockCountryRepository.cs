using System.Collections.Generic;

namespace WorldCheckMap.Data.Repositories.Country
{
    public class MockCountryRepository : ICountryRepository
    {
        public IEnumerable<Models.Country> GetCountries()
        {
            throw new System.NotImplementedException();
        }
    }
}
