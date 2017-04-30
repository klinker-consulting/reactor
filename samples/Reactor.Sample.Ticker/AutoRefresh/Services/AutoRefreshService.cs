using System;
using System.Reactive.Linq;
using Reactor.Core.Stores;
using Reactor.Sample.Ticker.AutoRefresh.Actions;

namespace Reactor.Sample.Ticker.AutoRefresh.Services
{
    public class AutoRefreshService
    {
        private readonly Store<State> _store;
        private IDisposable _timerSubscription;

        public AutoRefreshService(Store<State> store)
        {
            _store = store;
        }

        public void Start()
        {
            _timerSubscription = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(5))
                .Subscribe(OnTimeElapsed);
        }

        public void Stop()
        {
            _timerSubscription.Dispose();
        }

        private void OnTimeElapsed(long time)
        {
            _store.Dispatch(new AutoRefreshElapsedAction());
        }
    }
}
