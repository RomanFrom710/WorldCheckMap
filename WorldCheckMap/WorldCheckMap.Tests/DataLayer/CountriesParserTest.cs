using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Data.Initialization;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Tests.DataLayer
{
    [TestClass]
    public class CountriesParserTest
    {
        [TestMethod]
        public void SmokeTest()
        {
            var countries = CountriesParser.GetCountries();
            Assert.IsNotNull(countries);
            Assert.IsInstanceOfType(countries, typeof(IEnumerable<Country>));
            Assert.IsTrue(countries.Count > 0);
        }

        [TestMethod]
        public void QuantityTest()
        {
            var countries = CountriesParser.GetCountries();
            Assert.AreEqual(countries.Count, 180);
        }

        [TestMethod]
        public void CorrentInfoTest()
        {
            var countries = CountriesParser.GetCountries();
            var belarus = countries.Find(c => c.Name == "Belarus");
            var uk = countries.Find(c => c.Name == "United Kingdom");
            Assert.AreEqual(belarus.Code, "BLR");
            Assert.AreEqual(uk.Code, "GBR");
        }
    }
}
