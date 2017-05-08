using Reactor.Core.Actions;
using Reactor.Ticker.Wpf.Quotes.Models;

namespace Reactor.Ticker.Wpf.Quotes.Actions
{
    public class QuotesReceivedAction : IAction<QuoteModel>
    {
        public QuoteModel Payload { get; }

        public QuotesReceivedAction(QuoteModel payload)
        {
            Payload = payload;
        }
    }
}
