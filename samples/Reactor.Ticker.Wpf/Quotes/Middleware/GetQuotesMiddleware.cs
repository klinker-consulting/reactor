using System;
using System.Threading.Tasks;
using Reactor.Core.Actions;
using Reactor.Core.Dispatchers;
using Reactor.Core.Middleware;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;
using Reactor.Ticker.Wpf.General.Actions;
using Reactor.Ticker.Wpf.Quotes.Actions;
using Reactor.Ticker.Wpf.Quotes.Services;

namespace Reactor.Ticker.Wpf.Quotes.Middleware
{
    public class GetQuotesMiddleware : IMiddleware<State>
    {
        private readonly IActionDispatcher _actionDispatcher;
        private readonly IQuotesService _service;

        public GetQuotesMiddleware(IActionDispatcher actionDispatcher, IQuotesService service)
        {
            _actionDispatcher = actionDispatcher;
            _service = service;
        }

        public async void Apply(State state, IAction action)
        {
            if (!(action is RefreshAction))
                return;

            foreach (var symbol in state.Symbols)
                await RefreshSymbol(symbol);
        }

        private async Task RefreshSymbol(string symbol)
        {
            try
            {
                var quote = await _service.GetQuote(symbol);
                _actionDispatcher.Dispatch(new QuotesReceivedAction(quote));
            }
            catch (Exception ex)
            {
                _actionDispatcher.Dispatch(new ExceptionAction(ex));
            }
        }
    }
}
