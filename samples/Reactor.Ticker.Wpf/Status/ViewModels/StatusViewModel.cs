using System;
using System.Reactive.Linq;
using Caliburn.Micro;
using Reactor.Core.Stores;

namespace Reactor.Ticker.Wpf.Status.ViewModels
{
    public class StatusViewModel : PropertyChangedBase
    {
        public int ExceptionCount { get; private set; }

        public StatusViewModel(Store<State> store)
        {
            store.Select(s => s.Exceptions)
                .SubscribeOnDispatcher()
                .Subscribe(e =>
                {
                    ExceptionCount = e.Length;
                    NotifyOfPropertyChange(nameof(ExceptionCount));
                });
        }
    }
}
