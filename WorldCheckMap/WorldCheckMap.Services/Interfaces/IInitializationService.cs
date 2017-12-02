using System.Threading.Tasks;

namespace WorldCheckMap.Services.Interfaces
{
    public interface IInitializationService
    {
        Task InitializeDataAsync();
    }
}