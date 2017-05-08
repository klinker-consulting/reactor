using System;
using Reactor.Core.Actions;

namespace Reactor.Ticker.Wpf.General.Actions
{
    public class ExceptionAction : IAction<Exception>
    {
        public Exception Payload { get; }

        public ExceptionAction(Exception payload)
        {
            Payload = payload;
        }
    }
}
