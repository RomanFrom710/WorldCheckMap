using System.Collections.Generic;

namespace WorldCheckMap.DataAccess.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Models.Country> GetCountries();
    }
}