using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace JsonStorageManager.Exceptions
{
    public class ExceptionHandler<TRequest, TResponse, TException> :
        IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : Exception
    {
        private readonly ILogger<ExceptionHandler<TRequest, TResponse, TException>> _logger;

        public ExceptionHandler(
            ILogger<ExceptionHandler<TRequest, TResponse, TException>> logger)
        {
            _logger = logger;
        }

        public async Task Handle(
            TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "");
        }
    }
}
