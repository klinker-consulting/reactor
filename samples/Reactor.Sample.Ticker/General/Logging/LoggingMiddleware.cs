using System;
using Microsoft.Extensions.Logging;
using Reactor.Core.Actions;
using Reactor.Core.Middleware;

namespace Reactor.Sample.Ticker.General.Logging
{
    public class LoggingMiddleware : IMiddleware<State>
    {
        private readonly ILogger _logger;

        public LoggingMiddleware(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        }

        public void Apply(State state, IAction action)
        {
            _logger.LogInformation($"{action} was triggered @ {DateTime.Now}");
        }
    }
}
