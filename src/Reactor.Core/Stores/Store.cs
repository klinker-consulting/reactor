using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Reactor.Core.Actions;
using Reactor.Core.Dispatchers;
using Reactor.Core.Reducers;

namespace Reactor.Core.Stores
{
    public class Store<TState>
    {
        private readonly IActionDispatcher _dispatcher;
        private readonly BehaviorSubject<TState> _state;

        public Store(IActionReducer<TState> rootReducer, IActionDispatcher dispatcher, TState initialState = default(TState))
        {
            _dispatcher = dispatcher;
            _state = new BehaviorSubject<TState>(initialState);
            _dispatcher.Scan(initialState, rootReducer).Subscribe(s => _state.OnNext(s));
        }

        public IDisposable Subscribe(System.Action<TState> subscriber)
        {
            return _state.Subscribe(subscriber);
        }

        public IObservable<TProperty> Select<TProperty>(Func<TState, TProperty> selector)
        {
            return _state.Select(selector);
        }

        public void Dispatch(IAction action)
        {
            _dispatcher.Dispatch(action);
        }
    }
}