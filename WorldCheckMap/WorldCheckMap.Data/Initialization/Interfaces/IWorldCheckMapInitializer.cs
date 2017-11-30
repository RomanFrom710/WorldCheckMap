using System.Threading.Tasks;

namespace WorldCheckMap.Data.Initialization.Interfaces
{
    public interface IWorldCheckMapInitializer
    {
        Task InitializeWorldCheckMapDatabaseAsync();
    }
}