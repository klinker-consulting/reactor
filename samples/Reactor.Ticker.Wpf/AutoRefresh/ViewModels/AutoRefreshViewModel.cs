using System;
using System.Reactive.Linq;
using Caliburn.Micro;
using Reactor.Core.Stores;
using Reactor.Ticker.Wpf.AutoRefresh.Actions;

namespace Reactor.Ticker.Wpf.AutoRefresh.ViewModels
{
    public class AutoRefreshViewModel : PropertyChangedBase
    {
        private readonly Store<State> _store;

        public bool IsRefreshing { get; private set; }

        public string LastRefresh { get; private set; }

        public AutoRefreshViewModel(Store<State> store)
        {
            _store = store;
            store.Select(s => s.IsAutoRefreshing)
                .SubscribeOnDispatcher()
                .Subscribe(s =>
                {
                    IsRefreshing = s;
                    NotifyOfPropertyChange(nameof(IsRefreshing));
                });

            store.Select(s => s.LastRefresh)
                .SubscribeOnDispatcher()
                .Subscribe(s =>
                {
                    if (!s.HasValue)
                        return;

                    LastRefresh = s.Value.ToString("F");
                    NotifyOfPropertyChange(nameof(LastRefresh));
                });
        }

        public void Start()
        {
            _store.Dispatch(new StartAutoRefreshAction());
        }

        public void Stop()
        {
            _store.Dispatch(new StopAutoRefreshAction());
        }
    }
}
