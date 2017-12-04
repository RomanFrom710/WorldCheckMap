using WorldCheckMap.DataAccess.Initialization.Interfaces;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Services
{
    public class InitializationService : IInitializationService
    {
        private readonly IWorldCheckMapInitializer _initializer;

        public InitializationService(IWorldCheckMapInitializer initializer)
        {
            _initializer = initializer;
        }

        public void InitializeData()
        {
            _initializer.InitializeDatabase();
        }
    }
}