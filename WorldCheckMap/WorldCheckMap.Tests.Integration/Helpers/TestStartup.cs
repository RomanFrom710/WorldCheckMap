using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WorldCheckMap.DependencyInjection;
using WorldCheckMap.Web;

namespace WorldCheckMap.Tests.Integration.Helpers
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env) : base(env) { }

        protected override void AddContext(IServiceCollection services)
        {
            services.AddInMemoryContext();
        }
    }
}