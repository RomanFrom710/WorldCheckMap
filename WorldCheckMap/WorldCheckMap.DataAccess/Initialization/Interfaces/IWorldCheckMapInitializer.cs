using System.Threading.Tasks;

namespace WorldCheckMap.DataAccess.Initialization.Interfaces
{
    public interface IWorldCheckMapInitializer
    {
        Task InitializeDatabaseAsync();
    }
}