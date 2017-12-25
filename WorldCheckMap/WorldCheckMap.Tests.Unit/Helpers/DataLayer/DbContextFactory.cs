using Microsoft.EntityFrameworkCore;
using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Helpers.DataLayer
{
    internal class DbContextFactory
    {
        private static int _dbCounter;
        private readonly int _currentDbNumber;

        internal DbContextFactory()
        {
            _currentDbNumber = _dbCounter++;
        }

        internal WorldCheckMapContext GetContext()
        {
            var options = new DbContextOptionsBuilder<WorldCheckMapContext>()
                .UseInMemoryDatabase($"WorldCheckMapTests{_currentDbNumber}")
                .Options;
            return new WorldCheckMapContext(options);
        }
    }
}