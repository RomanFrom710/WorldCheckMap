using WorldCheckMap.DataAccess;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer.ContextFactory;

namespace WorldCheckMap.Tests.Unit.Infrastructure.Initializers
{
    public abstract class BaseDbInitializer
    {
        internal void Initialize(IDbContextFactory contextFactory)
        {
            using (var db = contextFactory.GetContext())
            {
                PopulateDbWithData(db);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Override this method to populate db with particular data.
        /// There's no need to call db.SaveChanges() here.
        /// </summary>
        protected abstract void PopulateDbWithData(WorldCheckMapContext db);
    }
}