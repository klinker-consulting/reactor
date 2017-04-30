using Reactor.Core.Actions;

namespace Reactor.Core.Middleware
{
    public interface IMiddleware<in TState>
    {
        void Apply(TState state, IAction action);
    }
}
