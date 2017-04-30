using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reactor.Core.Actions;
using Reactor.Core.Dispatchers;
using Reactor.Core.Reducers;
using Reactor.Core.Stores;
using Reactor.Core.Tests.Reducers;

namespace Reactor.Core.Tests.Stores
{

    [TestClass]
    public class StoreTests
    {
        private FakeActionReducer _fakeReducer;
        private RootReducer<FakeState> _rootReducer;
        private Store<FakeState> _store;
        private ActionDispatcher _dispatcher;

        [TestInitialize]
        public void Initialize()
        {
            _fakeReducer = new FakeActionReducer();
            _dispatcher = new ActionDispatcher();
            _rootReducer = new RootReducer<FakeState>(_fakeReducer);
            _store = new Store<FakeState>(_rootReducer, _dispatcher);
        }

        [TestMethod]
        public void DispatchShouldExecuteReducer()
        {
            var expected = new EmptyAction();
            _store.Dispatch(expected);
            Assert.AreSame(expected, _fakeReducer.Action);
        }

        [TestMethod]
        public void DispatchShouldNotifySubscribersOfNewState()
        {
            _store.Dispatch(new EmptyAction());
            Assert.IsNotNull(_fakeReducer.NewState);
        }
    }
}
