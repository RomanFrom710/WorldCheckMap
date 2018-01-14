using System;
using WorldCheckMap.DataAccess;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer.ContextFactory;
using WorldCheckMap.Tests.Unit.Infrastructure.Initializers;

namespace WorldCheckMap.Tests.Unit.Infrastructure.DataLayer
{
    internal class RepositoryTestRunner
    {
        private readonly BaseDbInitializer _dbInitializer;

        internal RepositoryTestRunner(BaseDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        internal void RunTest(Action<WorldCheckMapContext> test)
        {
            var contextFactory = new DbContextFactory();
            _dbInitializer.Initialize(contextFactory);

            using (var db = contextFactory.GetContext())
            {
                test(db);
            }
        }
    }
}