using Reactor.Core.Dispatchers;
using Reactor.Core.Middleware;
using Reactor.Core.Reducers;
using Reactor.Core.Stores;
using StructureMap;

namespace Reactor.Ticker.Wpf.General.DependencyInjection
{
    public class ReactorTickerRegistry : Registry
    {
        public ReactorTickerRegistry()
        {
            Scan(scanner =>
            {
                scanner.AddAllTypesOf<IActionReducer<State>>();
                scanner.AddAllTypesOf<IMiddleware<State>>();
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();
                scanner.WithDefaultConventions();
            });

            For<IActionDispatcher>()
                .Singleton()
                .Use<ActionDispatcher>();

            For<Store<State>>()
                .Singleton()
                .Use(ctx => CreateStore(ctx));
        }

        private static Store<State> CreateStore(IContext context)
        {
            var reducers = context.GetAllInstances<IActionReducer<State>>();
            var middleware = context.GetAllInstances<IMiddleware<State>>();
            var rootReducer = new RootReducer<State>(reducers, middleware);
            var dispatcher = context.GetInstance<IActionDispatcher>();
            return new Store<State>(rootReducer, dispatcher, new State());
        }
    }
}
