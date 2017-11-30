using System.Collections.Generic;

namespace WorldCheckMap.Data.Repositories.Country
{
    public interface ICountryRepository
    {
        IEnumerable<Models.Country> GetCountries();
    }
}