using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;

namespace Reactor.Ticker.Wpf.AutoRefresh.Reducers
{
    public class StartAutoRefreshReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var startAutoRefreshAction = action as StartAutoRefreshAction;
            if (startAutoRefreshAction == null)
                return state;

            return state.WithAutoRefresh(true);
        }
    }
}
