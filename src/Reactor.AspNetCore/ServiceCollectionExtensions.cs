using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Reactor.Core.Dispatchers;
using Reactor.Core.Middleware;
using Reactor.Core.Reducers;
using Reactor.Core.Stores;

namespace Reactor.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReactor<TState>(this IServiceCollection services, TState initialState = default(TState))
        {
            foreach (var reducerType in GetReducerTypes<TState>())
                services.AddTransient(typeof(IActionReducer<TState>), reducerType);

            foreach (var middlewareType in GetMiddlewareTypes<TState>())
                services.AddTransient(typeof(IMiddleware<TState>), middlewareType);

            return services
                .AddSingleton<IActionDispatcher, ActionDispatcher>()
                .AddSingleton(p => CreateStore(p, initialState));
        }

        private static Store<TState> CreateStore<TState>(IServiceProvider serviceProvider, TState initialState)
        {
            var reducers = serviceProvider.GetServices<IActionReducer<TState>>();
            var middleware = serviceProvider.GetServices<IMiddleware<TState>>();
            var rootReducer = new RootReducer<TState>(reducers, middleware);
            var dispacher = serviceProvider.GetService<IActionDispatcher>();
            return new Store<TState>(rootReducer, dispacher, initialState);
        }

        private static IEnumerable<Type> GetReducerTypes<TState>()
        {
            return typeof(TState).GetTypeInfo()
                .Assembly.ExportedTypes
                .Where(IsReducerType<TState>);
        }

        private static IEnumerable<Type> GetMiddlewareTypes<TState>()
        {
            return typeof(TState).GetTypeInfo()
                .Assembly.ExportedTypes
                .Where(IsMiddlewareType<TState>);
        }

        private static bool IsReducerType<TState>(Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces
                .Where(i => i.GetTypeInfo().IsGenericType)
                .Where(i => i.GetGenericTypeDefinition() == typeof(IActionReducer<>))
                .Any(i => i.GenericTypeArguments[0] == typeof(TState));
        }

        private static bool IsMiddlewareType<TState>(Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces
                .Where(i => i.GetTypeInfo().IsGenericType)
                .Where(i => i.GetGenericTypeDefinition() == typeof(IMiddleware<>))
                .Any(i => i.GenericTypeArguments[0] == typeof(TState));
        }
    }
}
