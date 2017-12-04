using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using WorldCheckMap.DataAccess.Initialization.Data;
using WorldCheckMap.DataAccess.Initialization.Interfaces;
using WorldCheckMap.DataAccess.Models;

namespace WorldCheckMap.DataAccess.Initialization
{
    public class JsonCountriesStorage : ICountriesStorage
    {
        public List<Country> GetCountries()
        {
            var jsonString = Encoding.Default.GetString(InitializationData.Countries);
            var countryTokens = JArray.Parse(jsonString);
            var countries = countryTokens.Select(ct => ct.ToObject<Country>()).ToList();
            return countries;
        }
    }
}
