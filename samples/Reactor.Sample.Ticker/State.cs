using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Reactor.Sample.Ticker.Quotes.Dtos;

namespace Reactor.Sample.Ticker
{
    public class State
    {
        public ImmutableArray<QuoteDto> Quotes { get; }

        public ImmutableArray<string> Symbols { get; }

        public State()
            : this(Enumerable.Empty<string>(), Enumerable.Empty<QuoteDto>())
        {
            
        }

        public State(IEnumerable<string> symbols, IEnumerable<QuoteDto> quotes)
        {
            Symbols = symbols.ToImmutableArray();
            Quotes = quotes.ToImmutableArray();
        }
    }
}
