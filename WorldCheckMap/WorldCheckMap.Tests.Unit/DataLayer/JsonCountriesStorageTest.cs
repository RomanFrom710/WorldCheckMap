using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Initialization;

namespace WorldCheckMap.Tests.Unit.DataLayer
{
    [TestClass]
    public class JsonCountriesStorageTest
    {
        [TestMethod]
        public void SmokeTest()
        {
            var storage = new JsonCountriesStorage();
            var countries = storage.GetCountries();
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Count > 0);
        }

        [TestMethod]
        public void QuantityTest()
        {
            var storage = new JsonCountriesStorage();
            var countries = storage.GetCountries();
            Assert.AreEqual(180, countries.Count);
        }

        [TestMethod]
        public void CorrentInfoTest()
        {
            var storage = new JsonCountriesStorage();
            var countries = storage.GetCountries();
            var belarus = countries.Find(c => c.Name == "Belarus");
            var uk = countries.Find(c => c.Name == "United Kingdom");
            Assert.AreEqual("BLR", belarus.Code);
            Assert.AreEqual("GBR", uk.Code);
        }
    }
}
