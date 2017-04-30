using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Sample.Ticker.Quotes.Actions;

namespace Reactor.Sample.Ticker.Quotes.Reducers
{
    public class QuotesRefreshedReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var quotesRefreshedAction = action as QuotesRefreshedAction;
            if (quotesRefreshedAction == null)
                return state;

            return new State(state.Symbols, quotesRefreshedAction.Payload);
        }
    }
}
