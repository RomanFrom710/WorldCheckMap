using WorldCheckMap.DataAccess;

namespace WorldCheckMap.Tests.Unit.Infrastructure.DataLayer.ContextFactory
{
    internal interface IDbContextFactory
    {
        WorldCheckMapContext GetContext();
    }
}