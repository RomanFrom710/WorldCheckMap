using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Infrastructure.Initializers
{
    public class EmptyInitializer : BaseDbInitializer
    {
        protected override void PopulateDbWithData(WorldCheckMapContext db)
        { }
    }
}