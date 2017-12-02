using System.Collections.Generic;

namespace WorldCheckMap.Data.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Models.Country> GetCountries();
    }
}