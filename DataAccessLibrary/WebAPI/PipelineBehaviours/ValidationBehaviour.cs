using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using WebAPI.Response;
using WebAPI.Validation;

namespace WebAPI.PipelineBehaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : BaseResponse, new()

    {
    private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
    private readonly IValidationHandler<TRequest> _validationHandler;

    //This constructor would run if we dont have Validator
    public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger,
        IValidationHandler<TRequest> validationHandler)
    {
        _logger = logger;
        _validationHandler = validationHandler;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var queryName = request?.GetType().DeclaringType?.Name ?? "Unknown Query Name";
        if (_validationHandler == null) return await next();

        var result = await _validationHandler.Validate(request);
        if (!result.IsSuccessful)
        {
            _logger.LogWarning($"Validation failed for {queryName}. Error ${result.Error}");
            return new TResponse {ErrorMessage = result.Error, StatusCode = HttpStatusCode.BadRequest};
        }

        _logger.LogInformation($"Validation Successful for {queryName}");
        return await next();

    }
    }
}
