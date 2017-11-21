using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data.Initialization
{
    internal static class CountriesParser
    {
        public static List<Country> GetCountries()
        {
            using (var r = new StreamReader("countries.json"))
            {
                var jsonString = r.ReadToEnd();
                var countryTokens = JArray.Parse(jsonString);
                var countries = countryTokens.Select(ct => ct.ToObject<Country>()).ToList();
                return countries;
            }
        }
    }
}
