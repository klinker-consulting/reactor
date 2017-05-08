using System;

namespace Reactor.Ticker.Wpf.Quotes.Models
{
    public class QuoteModel
    {
        public decimal LastPrice { get; }
        public string Symbol { get; }
        public string Name { get; }
        public DateTime Timestamp { get; }

        public QuoteModel(string symbol, string name, decimal lastPrice, DateTime timestamp)
        {
            Symbol = symbol;
            Name = name;
            LastPrice = lastPrice;
            Timestamp = timestamp;
        }
    }
}
