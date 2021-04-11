using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace WebAPI.PipelineBehaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest,TResponse>> logger)
        {
            _logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Pre logic
            _logger.LogInformation($"{request?.GetType().DeclaringType?.Name} is starting.");
            var timer = Stopwatch.StartNew();
            var response = next();
            timer.Stop();
            // Post Logic
            _logger.LogInformation($"{request?.GetType().DeclaringType?.Name} is finished in {timer.ElapsedMilliseconds}ms");
            return response;
        }
    }
}
