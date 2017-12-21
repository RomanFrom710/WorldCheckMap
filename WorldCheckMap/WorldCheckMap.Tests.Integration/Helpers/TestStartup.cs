using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldCheckMap.DependencyInjection;
using WorldCheckMap.Web;

namespace WorldCheckMap.Tests.Integration.Helpers
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration config) : base(config) { }

        protected override void AddContext(IServiceCollection services)
        {
            services.AddInMemoryContext();
        }
    }
}