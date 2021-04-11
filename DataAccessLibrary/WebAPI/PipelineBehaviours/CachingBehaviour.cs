using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using WebAPI.Contracts;

namespace WebAPI.PipelineBehaviours
{
    public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        private readonly ILogger<CachingBehaviour<TRequest, TResponse>> _logger;
        private readonly IMemoryCache _cache;

        public CachingBehaviour(ILogger<CachingBehaviour<TRequest,TResponse>> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var queryName = request?.GetType().DeclaringType?.Name ?? "Unknown Query Name";
            _logger.LogInformation($"{queryName} is configured for caching the response.");

            //Check if item is cached.
            if (_cache.TryGetValue(request?.CacheKey, out TResponse response))
            {
                _logger.LogInformation($"Restored cached value for {queryName} with key {request?.CacheKey}");
                return response;
            }
            _logger.LogInformation($"{queryName} - Cache Key {request?.CacheKey} - is not cached. executing..");
            response = await next();
            _cache.Set(request?.CacheKey, response);
            return response;
        }
    }
}
