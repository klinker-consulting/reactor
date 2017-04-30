using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Reactor.Core.Actions;
using Reactor.Core.Reducers;

namespace Reactor.Core.Dispatchers
{
    public interface IActionDispatcher
    {
        void Dispatch(IAction action);
        IObservable<TState> Scan<TState>(TState initialState, IActionReducer<TState> reducer);
    }

    public class ActionDispatcher : IActionDispatcher
    {
        private readonly BehaviorSubject<IAction> _actions;

        public ActionDispatcher()
        {
            _actions = new BehaviorSubject<IAction>(new InitializeAction());
        }

        public IObservable<TState> Scan<TState>(TState initialState, IActionReducer<TState> reducer)
        {
            return _actions.Scan(initialState, reducer.Reduce);
        }

        public void Dispatch(IAction action)
        {
            _actions.OnNext(action);
        }
    }
}
