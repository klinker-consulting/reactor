using Reactor.Core.Actions;

namespace Reactor.Ticker.Wpf.Symbols.Actions
{
    public class SymbolSelectedAction : IAction<string>
    {
        public string Payload { get; }

        public SymbolSelectedAction(string payload)
        {
            Payload = payload;
        }
    }
}
