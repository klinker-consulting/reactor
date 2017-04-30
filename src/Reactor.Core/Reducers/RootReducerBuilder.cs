using System.Collections.Generic;
using Reactor.Core.Middleware;

namespace Reactor.Core.Reducers
{
    public class RootReducerBuilder<TState>
    {
        private readonly List<IActionReducer<TState>> _reducers;
        private readonly List<IMiddleware<TState>> _middleware;

        public RootReducerBuilder()
        {
            _reducers = new List<IActionReducer<TState>>();
            _middleware = new List<IMiddleware<TState>>();
        }

        public RootReducerBuilder<TState> UseReducer(IActionReducer<TState> reducer)
        {
            _reducers.Add(reducer);
            return this;
        }

        public RootReducerBuilder<TState> UseMiddleware(IMiddleware<TState> middleware)
        {
            _middleware.Add(middleware);
            return this;
        }

        public RootReducer<TState> Build()
        {
            return new RootReducer<TState>(_reducers, _middleware);
        }
    }
}
