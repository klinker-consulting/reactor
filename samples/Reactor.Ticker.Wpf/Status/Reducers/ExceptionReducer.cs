using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Ticker.Wpf.General.Actions;

namespace Reactor.Ticker.Wpf.Status.Reducers
{
    public class ExceptionReducer : IActionReducer<State>
    {
        public State Reduce(State state, IAction action)
        {
            var exceptionAction = action as ExceptionAction;
            if (exceptionAction == null)
                return state;

            var exceptions = state.Exceptions.Add(exceptionAction.Payload);
            return state.WithExceptions(exceptions);
        }
    }
}
