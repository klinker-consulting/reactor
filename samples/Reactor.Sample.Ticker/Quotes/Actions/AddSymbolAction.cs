using Reactor.Core.Actions;

namespace Reactor.Sample.Ticker.Quotes.Actions
{
    public class AddSymbolAction : IAction<string>
    {
        public string Payload { get; }

        public AddSymbolAction(string payload)
        {
            Payload = payload;
        }
    }
}
