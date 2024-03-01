using System.Net;
using JsonStorageManager.BlobManager.Models;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace JsonStorageManager.BlobManager
{
    public class ListBlobsFunction
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ListBlobsFunction(
            ILoggerFactory loggerFactory,
            IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<ListBlobsFunction>();
            _mediator = mediator;
        }

        [Function("ListBlobs")]
        public async Task<HttpResponseData> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData httpRequest)
        {
            _logger.LogInformation("Start function: List all blobs from container.");

            var blobListResponse = await _mediator.Send(new GetBlobRequest());

            var httpResponse = httpRequest.CreateResponse(HttpStatusCode.OK);
            await httpResponse.WriteAsJsonAsync(blobListResponse.BlobList);

            _logger.LogInformation("Function List all blobs from container successfully finished.");

            return httpResponse;
        }
    }
}
