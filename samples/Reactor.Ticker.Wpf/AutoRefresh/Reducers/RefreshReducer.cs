using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;

namespace Reactor.Ticker.Wpf.AutoRefresh.Reducers
{
    public class RefreshReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var refreshAction = action as RefreshAction;
            if (refreshAction == null)
                return state;

            return state.WithLastRefresh(refreshAction.Payload);
        }
    }
}
