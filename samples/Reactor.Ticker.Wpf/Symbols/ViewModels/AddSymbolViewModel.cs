using Caliburn.Micro;
using Reactor.Core.Stores;
using Reactor.Ticker.Wpf.Symbols.Actions;

namespace Reactor.Ticker.Wpf.Symbols.ViewModels
{
    public class AddSymbolViewModel : PropertyChangedBase
    {
        private readonly Store<State> _store;
        private string _symbol;

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                NotifyOfPropertyChange(nameof(Symbol));
            }
        }

        public AddSymbolViewModel(Store<State> store)
        {
            _store = store;
        }

        public void AddSymbol()
        {
            _store.Dispatch(new AddSymbolAction(Symbol));
            Symbol = null;
        }
    }
}
