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
    }
}
