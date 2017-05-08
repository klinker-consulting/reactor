using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.Symbols.Actions;

namespace Reactor.Ticker.Wpf.Symbols.Reducers
{
    public class SymbolSelectedReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var symbolSelectedAction = action as SymbolSelectedAction;
            if (symbolSelectedAction == null)
                return state;

            return state.WithSelectedSymbol(symbolSelectedAction.Payload);
        }
    }
}
