namespace Reactor.Ticker.Wpf.General.Http
{
    public interface IHttpClientFactory
    {
        IHttpClient Create();
    }

    public class HttpClientFactory : IHttpClientFactory
    {
        public IHttpClient Create()
        {
            return new HttpClient();
        }
    }
}
