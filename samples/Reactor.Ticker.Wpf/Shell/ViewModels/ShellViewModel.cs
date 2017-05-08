using Caliburn.Micro;
using Reactor.Ticker.Wpf.AutoRefresh.ViewModels;
using Reactor.Ticker.Wpf.Quotes.ViewModels;
using Reactor.Ticker.Wpf.Status.ViewModels;
using Reactor.Ticker.Wpf.Symbols.ViewModels;

namespace Reactor.Ticker.Wpf.Shell.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        public AddSymbolViewModel AddSymbol { get; }
        public SymbolsViewModel Symbols { get; }
        public StatusViewModel Status { get; }
        public AutoRefreshViewModel AutoRefresh { get; }
        public QuotesViewModel Quotes { get; }

        public ShellViewModel(AddSymbolViewModel addSymbol, SymbolsViewModel symbols, StatusViewModel status, AutoRefreshViewModel autoRefresh, QuotesViewModel quotes)
        {
            AddSymbol = addSymbol;
            Symbols = symbols;
            Status = status;
            Quotes = quotes;
            AutoRefresh = autoRefresh;
        }
    }
}
