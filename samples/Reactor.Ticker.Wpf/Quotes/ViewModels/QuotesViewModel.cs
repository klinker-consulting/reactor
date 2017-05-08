using System;
using Caliburn.Micro;
using Reactor.Ticker.Wpf.Quotes.Models;
using System.Collections.Generic;
using System.Reactive.Linq;
using Reactor.Core.Stores;

namespace Reactor.Ticker.Wpf.Quotes.ViewModels
{
    public class QuotesViewModel : Screen
    {
        public string Symbol { get; private set; }
        public IEnumerable<QuoteModel> Quotes { get; private set; }

        public QuotesViewModel(Store<State> store)
        {
            store.Select(s => s.SelectedSymbol)
                .SubscribeOnDispatcher()
                .Subscribe(s =>
                {
                    Symbol = s;
                    NotifyOfPropertyChange(nameof(Symbol));
                });

            store.Select(s => s.QuotesForSymbol)
                .SubscribeOnDispatcher()
                .Subscribe(q =>
                {
                    Quotes = q;
                    NotifyOfPropertyChange(nameof(Quotes));
                });
        }
    }
}
