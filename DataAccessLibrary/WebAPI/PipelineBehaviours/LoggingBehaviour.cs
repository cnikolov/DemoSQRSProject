using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace WebAPI.PipelineBehaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        private const int Second = 1000;
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest,TResponse>> logger)
        {
            _logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Pre logic
            var queryName = request?.GetType().DeclaringType?.Name ?? "Unknown Query Name";
            _logger.LogInformation($"{queryName} is starting.");
            var timer = Stopwatch.StartNew();
            var response = next();
            timer.Stop();
            // Post Logic
            _logger.LogInformation($"{queryName} is finished in {timer.ElapsedMilliseconds}ms");
            if(timer.ElapsedMilliseconds > Second)
                _logger.LogWarning($"{queryName} took longer than it should take ${timer.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
