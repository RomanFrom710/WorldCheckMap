using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using WorldCheckMap.Data.Initialization.Data;
using WorldCheckMap.Data.Initialization.Interfaces;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data.Initialization
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
