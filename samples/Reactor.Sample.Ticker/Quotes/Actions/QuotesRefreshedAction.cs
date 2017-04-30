using Reactor.Core.Actions;
using Reactor.Sample.Ticker.Quotes.Dtos;

namespace Reactor.Sample.Ticker.Quotes.Actions
{
    public class QuotesRefreshedAction : IAction<QuoteDto[]>
    {
        public QuoteDto[] Payload { get; }

        public QuotesRefreshedAction(QuoteDto[] payload)
        {
            Payload = payload;
        }
    }
}
