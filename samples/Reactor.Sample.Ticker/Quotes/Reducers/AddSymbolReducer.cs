using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Sample.Ticker.Quotes.Actions;

namespace Reactor.Sample.Ticker.Quotes.Reducers
{
    public class AddSymbolReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var addSymbolAction = action as AddSymbolAction;
            if (addSymbolAction == null)
                return state;

            return state.Symbols.Contains(addSymbolAction.Payload) 
                ? state 
                : new State(state.Symbols.Add(addSymbolAction.Payload), state.Quotes);

            ;
        }
    }
}
