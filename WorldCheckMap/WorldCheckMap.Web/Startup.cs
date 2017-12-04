using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorldCheckMap.DependencyInjection;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddNodeServices();
            services.AddAutoMapper();

            AddContext(services);
            services.AddDataLayerConnector();
            services.AddServiceLayerConnector();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                SetupDevelopmentFeatures(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            SetupMvc(app);
            InitializeData(app);
        }

        protected virtual void AddContext(IServiceCollection services)
        {
            services.AddSqlContext(Configuration.GetConnectionString("WorldCheckMap"));
        }


        private void SetupDevelopmentFeatures(IApplicationBuilder app)
        {
            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
                HotModuleReplacement = true,
                ReactHotModuleReplacement = true,
                HotModuleReplacementClientOptions = new Dictionary<string, string>
                {
                    { "dynamicPublicPath", "true" }
                }
            });

            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
        }

        private void SetupMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private void InitializeData(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<IInitializationService>();
                initializer.InitializeData();
            }
        }
    }
}
