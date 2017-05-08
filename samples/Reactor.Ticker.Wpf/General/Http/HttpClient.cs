using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Reactor.Ticker.Wpf.General.Http
{
    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }

    public class HttpClient : System.Net.Http.HttpClient, IHttpClient
    {
    }
}
