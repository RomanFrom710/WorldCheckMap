using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Tests.Integration.Helpers;

namespace WorldCheckMap.Tests.Integration
{
    [TestClass]
    public class CountriesTest
    {
        [TestMethod]
        public async Task GetCountriesTest()
        {
            var client = ClientBuilder.GetClient();
            var response = await client.GetAsync("/api/countries");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var countryTokens = JArray.Parse(jsonString);
            var countries = countryTokens.Select(ct => ct.ToObject<CountryDto>()).ToList();

            Assert.IsNotNull(countries);
            Assert.AreEqual(countries.Count, 180);

            var belarus = countries.Find(c => c.Name == "Belarus");
            var uk = countries.Find(c => c.Name == "United Kingdom");
            Assert.AreEqual(belarus.Code, "BLR");
            Assert.AreEqual(uk.Code, "GBR");
        }
    }
}