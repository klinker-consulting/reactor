using System;

namespace Reactor.Sample.Ticker.Quotes.Dtos
{
    public class QuoteDto
    {
        public string Name { get; }
        public decimal LastPrice { get; }
        public decimal Change { get; }
        public string Symbol { get; }
        public DateTime Timestamp { get; }

        public QuoteDto(string name, 
            decimal lastPrice, 
            decimal change, 
            string symbol, 
            DateTime timestamp)
        {
            Name = name;
            LastPrice = lastPrice;
            Change = change;
            Symbol = symbol;
            Timestamp = timestamp;
        }
    }
}
