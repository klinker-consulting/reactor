using System;
using Reactor.Core.Actions;

namespace Reactor.Ticker.Wpf.AutoRefresh.Actions
{
    public class RefreshAction : IAction<DateTime>
    {
        public DateTime Payload { get; }

        public RefreshAction(DateTime payload)
        {
            Payload = payload;
        }
    }
}
