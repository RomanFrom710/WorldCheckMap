using Microsoft.EntityFrameworkCore;
using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Helpers
{
    internal static class DbContextBuilder
    {
        private static int _dbCounter;

        internal static WorldCheckMapContext GetContext()
        {
            var options = new DbContextOptionsBuilder<WorldCheckMapContext>()
                .UseInMemoryDatabase($"WorldCheckMapTests{_dbCounter++}")
                .Options;
            return new WorldCheckMapContext(options);
        }
    }
}