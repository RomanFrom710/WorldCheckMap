using System.Threading.Tasks;

namespace WorldCheckMap.Services.Initialization
{
    public interface IInitializationService
    {
        Task InitializeDataAsync();
    }
}