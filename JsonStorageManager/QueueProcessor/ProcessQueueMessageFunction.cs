using JsonStorageManager.QueueProcessor.Models;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace JsonStorageManager.QueueProcessor
{
    public class ProcessQueueMessageFunction
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ProcessQueueMessageFunction(
            ILoggerFactory loggerFactory,
            IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<ProcessQueueMessageFunction>();
            _mediator = mediator;
        }

        [Function("ProcessQueueMessage")]
        [BlobOutput("%blobContainerName%/{DateTime:yyyy/MM/dd/HH/mm}/{rand-guid}.json", Connection = "queueConnectionString")]
        public async Task<string> RunAsync(
            [QueueTrigger("%queueName%", Connection = "queueConnectionString")] string myQueueItem)
        {
            _logger.LogInformation("Start function: Process queue message: {myQueueItem}", myQueueItem);

            var response = await _mediator.Send(new ValidatorRequest(Message: myQueueItem));
            if (response.IsValid)
            {
                return myQueueItem;
            }

            throw new ArgumentException($"Invalid input message: {myQueueItem}.");
        }
    }
}
