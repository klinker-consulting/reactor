using Reactor.Core.Middleware;
using Reactor.Core.Actions;
using Reactor.Core.Tests.Stores;

namespace Reactor.Core.Tests.Middleware
{
    public class FakeMiddleware : IMiddleware<FakeState>
    {
        public IAction Action { get; private set; }
        public FakeState State { get; private set; }

        public void Apply(FakeState state, IAction action)
        {
            Action = action;
            State = state;
        }
    }
}
