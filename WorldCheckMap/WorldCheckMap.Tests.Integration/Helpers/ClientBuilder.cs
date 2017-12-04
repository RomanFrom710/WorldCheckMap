using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using WorldCheckMap.Web;

namespace WorldCheckMap.Tests.Integration.Helpers
{
    internal static class ClientBuilder
    {
        private static TestServer _commonServer;

        private static TestServer GetTestServer()
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
            //var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);
            return new TestServer(new WebHostBuilder()
                .UseContentRoot(new Uri(startupAssembly.CodeBase).AbsolutePath)
                .UseStartup<Startup>());
        }

        internal static HttpClient GetClient()
        {
            if (_commonServer == null)
            {
                _commonServer = GetTestServer();
            }

            return _commonServer.CreateClient();
        }

        internal static HttpClient GetNewServerClient()
        {
            return GetTestServer().CreateClient();
        }
    }
}