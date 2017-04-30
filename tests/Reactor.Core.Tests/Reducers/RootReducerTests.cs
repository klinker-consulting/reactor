using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reactor.Core.Actions;
using Reactor.Core.Reducers;
using Reactor.Core.Tests.Middleware;
using Reactor.Core.Tests.Stores;

namespace Reactor.Core.Tests.Reducers
{
    [TestClass]
    public class RootReducerTests
    {
        private FakeActionReducer _actionReducer;
        private FakeMiddleware _middleware;
        private RootReducer<FakeState> _rootReducer;

        [TestInitialize]
        public void Initialize()
        {
            _middleware = new FakeMiddleware();
            _actionReducer = new FakeActionReducer();
            _rootReducer = new RootReducerBuilder<FakeState>()
                .UseReducer(_actionReducer)
                .UseMiddleware(_middleware)
                .Build();
        }

        [TestMethod]
        public void ReduceShouldExecuteEachReducer()
        {
            var action = new EmptyAction();
            var oldState = new FakeState();

            var newState = _rootReducer.Reduce(oldState, action);
            Assert.AreSame(action, _actionReducer.Action);
            Assert.AreSame(oldState, _actionReducer.PreviousState);
            Assert.AreNotSame(newState, oldState);
        }

        [TestMethod]
        public void ReduceShouldApplyMiddleware()
        {
            var fakeState = new FakeState();
            var emptyAction = new EmptyAction();

            _rootReducer.Reduce(fakeState, emptyAction);
            Assert.AreEqual(fakeState, _middleware.State);
            Assert.AreEqual(emptyAction, _middleware.Action);
        }
    }
}
