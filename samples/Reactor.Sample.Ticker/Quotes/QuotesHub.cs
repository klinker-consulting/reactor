using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Reactor.Sample.Ticker.Quotes.Dtos;

namespace Reactor.Sample.Ticker.Quotes
{
    public interface IQuotesHub
    {
        Task SendQuotes(IEnumerable<QuoteDto> quotes);
        Task SendFailedQuotes(string error);
    }

    public class QuotesHub : Hub, IQuotesHub
    {
        public async Task SendQuotes(IEnumerable<QuoteDto> quotes)
        {
            if (Clients?.All == null)
                return;
            await Clients.All.InvokeAsync("SendQuotes", quotes);
        }

        public async Task SendFailedQuotes(string error)
        {
            if (Clients.All == null)
                return;

            await Clients.All.InvokeAsync("SendFailedQuotes", error);
        }
    }
}
