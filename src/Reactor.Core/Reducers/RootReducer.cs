using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Reactor.Core.Actions;
using Reactor.Core.Middleware;

namespace Reactor.Core.Reducers
{
    public class RootReducer<TState> : IActionReducer<TState>
    {
        private readonly ImmutableArray<IActionReducer<TState>> _reducers;
        private readonly ImmutableArray<IMiddleware<TState>> _middlewares;

        public RootReducer(params IActionReducer<TState>[] reducers)
            : this((IEnumerable<IActionReducer<TState>>) reducers.ToArray(), Enumerable.Empty<IMiddleware<TState>>())
        {
            
        }

        public RootReducer(IEnumerable<IActionReducer<TState>> reducers)
            : this(reducers, Enumerable.Empty<IMiddleware<TState>>())
        {
            
        }

        public RootReducer(IEnumerable<IActionReducer<TState>> reducers, IEnumerable<IMiddleware<TState>> middleware)
        {
            _reducers = reducers.ToImmutableArray();
            _middlewares = middleware.ToImmutableArray();
        }

        public TState Reduce(TState state, IAction action)
        {
            foreach (var middleware in _middlewares)
                middleware.Apply(state, action);
            return _reducers.Aggregate(state, (s, r) => r.Reduce(s, action));
        }
    }
}
