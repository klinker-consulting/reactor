using Reactor.Core.Actions;

namespace Reactor.Core.Reducers
{
    public interface IActionReducer<TState>
    {
        TState Reduce(TState state, IAction action);
    }
}
