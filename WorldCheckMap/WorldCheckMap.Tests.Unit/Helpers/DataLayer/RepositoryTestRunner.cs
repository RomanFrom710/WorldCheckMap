using System;
using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Helpers.DataLayer
{
    internal class RepositoryTestRunner<T>
    {
        private readonly Func<WorldCheckMapContext, T> _repositoryCreator;

        internal RepositoryTestRunner(Func<WorldCheckMapContext, T> repositoryCreator)
        {
            _repositoryCreator = repositoryCreator;
        }

        internal void RunTest(Action<WorldCheckMapContext> initialization, Action<WorldCheckMapContext, T> test)
        {
            var contextFactory = new DbContextFactory();

            using (var db = contextFactory.GetContext())
            {
                initialization(db);
                db.SaveChanges();
            }

            using (var db = contextFactory.GetContext())
            {
                var repository = _repositoryCreator(db);
                test(db, repository);
            }
        }
    }
}