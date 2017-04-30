namespace Reactor.Sample.Ticker.Quotes.Dtos
{
    public class AddSymbolDto
    {
        public string Symbol { get; }

        public AddSymbolDto(string symbol)
        {
            Symbol = symbol;
        }
    }
}
