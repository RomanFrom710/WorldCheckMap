using Microsoft.EntityFrameworkCore;
using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Infrastructure.DataLayer.ContextFactory
{
    internal class DbContextFactory : IDbContextFactory
    {
        private static int _dbCounter;
        private readonly int _currentDbNumber;

        internal DbContextFactory()
        {
            _currentDbNumber = _dbCounter++;
        }

        public WorldCheckMapContext GetContext()
        {
            var options = new DbContextOptionsBuilder<WorldCheckMapContext>()
                .UseInMemoryDatabase($"WorldCheckMapTests{_currentDbNumber}")
                .Options;
            return new WorldCheckMapContext(options);
        }
    }
}