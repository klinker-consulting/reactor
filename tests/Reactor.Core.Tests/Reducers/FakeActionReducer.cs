using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Core.Tests.Stores;

namespace Reactor.Core.Tests.Reducers
{
    public class FakeActionReducer : IActionReducer<FakeState>
    {
        public FakeState PreviousState { get; private set; }
        public IAction Action { get; private set; }
        public FakeState NewState { get; private set; }

        public FakeState Reduce(FakeState state, IAction action)
        {
            PreviousState = state;
            Action = action;
            return (NewState = new FakeState());
        }
    }
}
