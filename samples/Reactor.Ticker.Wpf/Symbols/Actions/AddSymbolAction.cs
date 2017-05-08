using Reactor.Core.Actions;

namespace Reactor.Ticker.Wpf.Symbols.Actions
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
