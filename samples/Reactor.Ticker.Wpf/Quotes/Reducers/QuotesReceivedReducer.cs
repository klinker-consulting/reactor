using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.Quotes.Actions;

namespace Reactor.Ticker.Wpf.Quotes.Reducers
{
    public class QuotesReceivedReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var quotesReceivedAction = action as QuotesReceivedAction;
            if (quotesReceivedAction == null)
                return state;

            var allQuotes = state.AllQuotes.Add(quotesReceivedAction.Payload);
            return state.WithAllQuotes(allQuotes);
        }
    }
}
