using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Reactor.Sample.Ticker.General.Http
{
    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }

    public class HttpClient : System.Net.Http.HttpClient, IHttpClient
    {
    }
}
