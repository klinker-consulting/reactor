namespace Reactor.Ticker.Wpf.Quotes.Models
{
    public class SymbolModel
    {
        public string Symbol { get; }
        public string Name { get; }

        public SymbolModel(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }
    }
}
