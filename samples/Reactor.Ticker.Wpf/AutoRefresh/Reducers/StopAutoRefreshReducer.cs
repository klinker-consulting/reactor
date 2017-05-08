using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;

namespace Reactor.Ticker.Wpf.AutoRefresh.Reducers
{
    public class StopAutoRefreshReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var stopAutoRefreshAction = action as StopAutoRefreshAction;
            if (stopAutoRefreshAction == null)
                return state;

            return state.WithAutoRefresh(false);
        }
    }
}
