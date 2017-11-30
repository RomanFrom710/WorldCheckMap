using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Data.Repositories.Country;

namespace WorldCheckMap.Tests.DataLayer
{
    [TestClass]
    public class CountryRepositoryTest
    {
        [TestMethod]
        public void SmokeTest()
        {
            Assert.IsNotNull(_repository);
        }
    }
}