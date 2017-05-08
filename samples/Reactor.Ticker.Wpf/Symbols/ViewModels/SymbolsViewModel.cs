using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Caliburn.Micro;
using Reactor.Core.Stores;
using Reactor.Ticker.Wpf.Symbols.Actions;

namespace Reactor.Ticker.Wpf.Symbols.ViewModels
{
    public class SymbolsViewModel : PropertyChangedBase
    {
        private readonly Store<State> _store;

        public IEnumerable<string> Symbols { get; private set; }
        public string SelectedSymbol { get; private set; }

        public SymbolsViewModel(Store<State> store)
        {
            _store = store;
            store.Select(s => s.Symbols)
                .SubscribeOnDispatcher()
                .Subscribe(s =>
                {
                    Symbols = s;
                    NotifyOfPropertyChange(nameof(Symbols));
                });

            store.Select(s => s.SelectedSymbol)
                .SubscribeOnDispatcher()
                .Subscribe(s =>
                {
                    SelectedSymbol = s;
                    NotifyOfPropertyChange(nameof(SelectedSymbol));
                });
        }

        public void SelectSymbol(string symbol)
        {
            _store.Dispatch(new SymbolSelectedAction(symbol));
        }
    }
}
