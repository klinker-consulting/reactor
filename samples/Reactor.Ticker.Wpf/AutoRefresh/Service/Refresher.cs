using System;
using System.Reactive.Linq;
using Reactor.Core.Dispatchers;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;
using Reactor.Ticker.Wpf.General.Background;

namespace Reactor.Ticker.Wpf.AutoRefresh.Service
{
    public interface IRefresher : IBackgroundService
    {
        
    }

    public class Refresher : IRefresher
    {
        private readonly IActionDispatcher _actionDispatcher;
        private IDisposable _timer;

        public Refresher(IActionDispatcher actionDispatcher)
        {
            _actionDispatcher = actionDispatcher;
        }

        public void Start()
        {
            _timer = Observable.Interval(TimeSpan.FromSeconds(2))
                .Subscribe(l => _actionDispatcher.Dispatch(new RefreshAction(DateTime.Now)));
        }

        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }
    }
}
