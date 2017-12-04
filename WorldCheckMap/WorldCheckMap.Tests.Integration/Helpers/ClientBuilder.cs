using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace WorldCheckMap.Tests.Integration.Helpers
{
    internal static class ClientBuilder
    {
        private static TestServer _commonServer;

        private static TestServer GetTestServer()
        {
            return new TestServer(new WebHostBuilder()
                .UseContentRoot(Path.GetFullPath(@"../../../../WorldCheckMap.Web/")) // not nice...
                .UseStartup<TestStartup>());
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