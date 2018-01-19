using WorldCheckMap.DataAccess.Initialization.Interfaces;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Services
{
    public class DatabaseInitializationService : IDatabaseInitializationService
    {
        private readonly IWorldCheckMapInitializer _initializer;

        public DatabaseInitializationService(IWorldCheckMapInitializer initializer)
        {
            _initializer = initializer;
        }

        public void InitializeData()
        {
            _initializer.InitializeDatabase();
        }
    }
}