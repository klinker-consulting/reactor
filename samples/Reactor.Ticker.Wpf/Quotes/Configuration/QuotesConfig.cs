using System.Configuration;

namespace Reactor.Ticker.Wpf.Quotes.Configuration
{
    public interface IQuotesConfig
    {
        string GetApiBaseUrl();
    }

    public class QuotesConfig : IQuotesConfig
    {
        public string GetApiBaseUrl()
        {
            return ConfigurationManager.AppSettings["ApiUrl"];
        }
    }
}
