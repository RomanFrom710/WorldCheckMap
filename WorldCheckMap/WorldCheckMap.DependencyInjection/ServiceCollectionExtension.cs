using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCheckMap.Data;
using WorldCheckMap.Data.Initialization;
using WorldCheckMap.Data.Initialization.Interfaces;
using WorldCheckMap.Data.Repositories;
using WorldCheckMap.Data.Repositories.Interfaces;
using WorldCheckMap.Services;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceLayerConnector(this IServiceCollection services)
        {
            return services
                .AddScoped<IInitializationService, InitializationService>();
        }

        public static IServiceCollection AddDataLayerConnector(this IServiceCollection services)
        {
            return services
                .AddScoped<IWorldCheckMapInitializer, IWorldCheckMapInitializer>()
                .AddScoped<ICountriesStorage, JsonCountriesStorage>()
                .AddScoped<ICountryRepository, CountryRepository>();
        }

        public static IServiceCollection AddSqlContext(this IServiceCollection services, string connectionString)
        {
            return 
                services.AddDbContext<WorldCheckMapContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
