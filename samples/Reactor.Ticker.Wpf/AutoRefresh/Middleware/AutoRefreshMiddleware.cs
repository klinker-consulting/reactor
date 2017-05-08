using Reactor.Core.Actions;
using Reactor.Core.Middleware;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;
using Reactor.Ticker.Wpf.AutoRefresh.Service;

namespace Reactor.Ticker.Wpf.AutoRefresh.Middleware
{
    public class AutoRefreshMiddleware : IMiddleware<State>
    {
        private readonly IRefresher _refresher;

        public AutoRefreshMiddleware(IRefresher refresher)
        {
            _refresher = refresher;
        }

        public void Apply(State state, IAction action)
        {
            if (action is StartAutoRefreshAction)
                _refresher.Start();

            if (action is StopAutoRefreshAction)
                _refresher.Stop();
        }
    }
}
