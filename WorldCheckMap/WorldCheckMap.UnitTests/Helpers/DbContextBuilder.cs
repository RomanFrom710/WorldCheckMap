using Microsoft.EntityFrameworkCore;
using WorldCheckMap.Data;

namespace WorldCheckMap.Tests.Helpers
{
    internal static class DbContextBuilder
    {
        internal static WorldCheckMapContext GetContext()
        {
            var options = new DbContextOptionsBuilder<WorldCheckMapContext>()
                .UseInMemoryDatabase("WorldCheckMapTests")
                .Options;
            return new WorldCheckMapContext(options);
        }
    }
}