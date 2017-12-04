﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCheckMap.DataAccess;
using WorldCheckMap.DataAccess.Initialization;
using WorldCheckMap.DataAccess.Initialization.Interfaces;
using WorldCheckMap.DataAccess.Repositories;
using WorldCheckMap.DataAccess.Repositories.Interfaces;
using WorldCheckMap.Services;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceLayerConnector(this IServiceCollection services)
        {
            return services
                .AddScoped<IInitializationService, InitializationService>()
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<IAccountService, AccountService>();
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
