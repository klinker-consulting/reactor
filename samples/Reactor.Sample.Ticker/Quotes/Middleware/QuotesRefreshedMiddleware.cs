using Reactor.Core.Actions;
using Reactor.Core.Middleware;
using Reactor.Sample.Ticker.Quotes.Actions;

namespace Reactor.Sample.Ticker.Quotes.Middleware
{
    public class QuotesRefreshedMiddleware : IMiddleware<State>
    {
        private readonly IQuotesHub _quotesHub;

        public QuotesRefreshedMiddleware(IQuotesHub quotesHub)
        {
            _quotesHub = quotesHub;
        }

        public async void Apply(State state, IAction action)
        {
            var quotesRefreshedAction = action as QuotesRefreshedAction;
            if (quotesRefreshedAction == null)
                return;

            await _quotesHub.SendQuotes(state.Quotes);
        }
    }
}
