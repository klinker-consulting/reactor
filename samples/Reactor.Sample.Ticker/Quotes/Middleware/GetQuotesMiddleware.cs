using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Reactor.Core.Middleware;
using Reactor.Core.Actions;
using Reactor.Core.Dispatchers;
using Reactor.Sample.Ticker.AutoRefresh.Actions;
using Reactor.Sample.Ticker.General.Http;
using Reactor.Sample.Ticker.Quotes.Actions;
using Reactor.Sample.Ticker.Quotes.Dtos;

namespace Reactor.Sample.Ticker.Quotes.Middleware
{
    public class GetQuotesMiddleware : IMiddleware<State>
    {
        private readonly IActionDispatcher _dispatcher;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl;

        public GetQuotesMiddleware(IActionDispatcher dispatcher, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _dispatcher = dispatcher;
            _httpClientFactory = httpClientFactory;
            _apiUrl = configuration["Quotes:ApiUrl"];
        }

        public async void Apply(State state, IAction action)
        {
            if (!(action is AutoRefreshElapsedAction))
                return;

            var tasks = state.Symbols.Select(GetQuoteForSymbol);
            var results = await Task.WhenAll(tasks);
            _dispatcher.Dispatch(new QuotesRefreshedAction(results));
        }

        private async Task<QuoteDto> GetQuoteForSymbol(string symbol)
        {
            using (var client = _httpClientFactory.Create())
            {
                var response = await client.GetAsync($"{_apiUrl}/json?{symbol}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuoteDto>(json);
            }
        }
    }
}
