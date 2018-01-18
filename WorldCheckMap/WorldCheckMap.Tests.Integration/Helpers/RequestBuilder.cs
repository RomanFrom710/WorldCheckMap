using System.Net.Http;
using System.Text;

namespace WorldCheckMap.Tests.Integration.Helpers
{
    internal static class RequestBuilder
    {
        internal static StringContent GetStringContentObject(string content)
        {
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}
