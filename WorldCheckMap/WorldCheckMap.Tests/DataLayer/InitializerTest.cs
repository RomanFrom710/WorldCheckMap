using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.Data.Repositories.Country;

namespace WorldCheckMap.Tests.DataLayer
{
    [TestClass]
    public class InitializerTest
    {
        [TestMethod]
        public void SmokeTest()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                // ...
            }
        }
    }
}