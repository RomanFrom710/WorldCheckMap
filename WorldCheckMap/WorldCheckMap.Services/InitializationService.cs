using System.Threading.Tasks;
using WorldCheckMap.Data.Initialization;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Services
{
    public class InitializationService : IInitializationService
    {
        private readonly WorldCheckMapInitializer _initializer;

        public InitializationService(WorldCheckMapInitializer initializer)
        {
            _initializer = initializer;
        }

        public async Task InitializeDataAsync()
        {
            await _initializer.InitializeDatabaseAsync();
        }
    }
}