using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.Symbols.Actions;

namespace Reactor.Ticker.Wpf.Symbols.Reducers
{
    public class AddSymbolReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var addSymbolAction = action as AddSymbolAction;
            if (addSymbolAction == null)
                return state;

            return state.WithSymbols(state.Symbols.Add(addSymbolAction.Payload));
        }
    }
}
