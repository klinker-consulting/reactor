using System.Threading.Tasks;
using Newtonsoft.Json;
using Reactor.Ticker.Wpf.General.Http;
using Reactor.Ticker.Wpf.Quotes.Configuration;
using Reactor.Ticker.Wpf.Quotes.Models;

namespace Reactor.Ticker.Wpf.Quotes.Services
{
    public interface IQuotesService
    {
        Task<QuoteModel> GetQuote(string symbol);
    }

    public class QuotesService : IQuotesService
    {
        private readonly IQuotesConfig _quotesConfig;
        private readonly IHttpClientFactory _httpClientFactory;

        public QuotesService(IQuotesConfig quotesConfig, IHttpClientFactory httpClientFactory)
        {
            _quotesConfig = quotesConfig;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<QuoteModel> GetQuote(string symbol)
        {
            using (var client = _httpClientFactory.Create())
            {
                var response = await client.GetAsync($"{_quotesConfig.GetApiBaseUrl()}/Quote?symbol={symbol}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuoteModel>(json);
            }
        }
    }
}
