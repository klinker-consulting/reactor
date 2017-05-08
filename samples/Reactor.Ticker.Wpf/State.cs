using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Reactor.Ticker.Wpf.Quotes.Models;

namespace Reactor.Ticker.Wpf
{
    public class State
    {
        public ImmutableArray<QuoteModel> AllQuotes { get; }

        public ImmutableArray<QuoteModel> QuotesForSymbol => AllQuotes.Where(s => s.Symbol == SelectedSymbol).ToImmutableArray();

        public ImmutableArray<string> Symbols { get; }

        public string SelectedSymbol { get; }

        public ImmutableArray<Exception> Exceptions { get; }

        public bool IsAutoRefreshing { get; }

        public DateTime? LastRefresh { get; }

        public State()
            : this(ImmutableArray<string>.Empty, null, ImmutableArray<QuoteModel>.Empty, ImmutableArray<Exception>.Empty, false, null)
        {
            
        }

        public State(ImmutableArray<string> symbols, string selectedSymbol, ImmutableArray<QuoteModel> allQuotes, ImmutableArray<Exception> exceptions, bool isAutoRefreshing, DateTime? lastRefresh)
        {
            Symbols = symbols;
            AllQuotes = allQuotes;
            Exceptions = exceptions;
            IsAutoRefreshing = isAutoRefreshing;
            LastRefresh = lastRefresh;
            SelectedSymbol = selectedSymbol;
        }

        public State WithSelectedSymbol(string symbol)
        {
            return new State(Symbols, symbol, AllQuotes, Exceptions, IsAutoRefreshing, LastRefresh);
        }

        public State WithAllQuotes(IEnumerable<QuoteModel> quotes)
        {
            return new State(Symbols, SelectedSymbol, quotes.ToImmutableArray(), Exceptions, IsAutoRefreshing, LastRefresh);
        }

        public State WithAutoRefresh(bool isAutoRefreshing)
        {
            return new State(Symbols, SelectedSymbol, AllQuotes, Exceptions, isAutoRefreshing, LastRefresh);
        }

        public State WithSymbols(IEnumerable<string> symbols)
        {
            return new State(symbols.ToImmutableArray(), SelectedSymbol, AllQuotes, Exceptions, IsAutoRefreshing, LastRefresh);
        }

        public State WithExceptions(IEnumerable<Exception> exceptions)
        {
            return new State(Symbols, SelectedSymbol, AllQuotes, exceptions.ToImmutableArray(), IsAutoRefreshing, LastRefresh);
        }

        public State WithLastRefresh(DateTime lastRefresh)
        {
            return new State(Symbols, SelectedSymbol, AllQuotes, Exceptions, IsAutoRefreshing, lastRefresh);
        }
    }
}
