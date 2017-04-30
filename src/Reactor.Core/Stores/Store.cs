using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Reactor.Core.Actions;
using Reactor.Core.Reducers;

namespace Reactor.Core.Stores
{
    public class Store<TState>
    {
        private readonly BehaviorSubject<IAction> _actions;
        private readonly BehaviorSubject<TState> _state;

        public Store(IActionReducer<TState> rootReducer, TState initialState = default(TState))
        {
            _actions = new BehaviorSubject<IAction>(new InitializeAction());
            _state = new BehaviorSubject<TState>(initialState);
            _actions.Scan(initialState, rootReducer.Reduce)
                .Subscribe(s => _state.OnNext(s));
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
            _actions.OnNext(action);
        }
    }
}