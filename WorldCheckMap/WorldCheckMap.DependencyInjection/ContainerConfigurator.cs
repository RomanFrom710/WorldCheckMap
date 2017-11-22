using Autofac;
using WorldCheckMap.Data;
using WorldCheckMap.Services;

namespace WorldCheckMap.DependencyInjection
{
    public static class ContainerConfigurator
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new ServiceModule());
        }
    }
}