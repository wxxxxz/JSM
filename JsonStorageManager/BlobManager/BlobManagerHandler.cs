using JsonStorageManager.BlobManager.Models;
using MediatR;

namespace JsonStorageManager.BlobManager
{
    internal class BlobManagerHandler : IRequestHandler<GetBlobRequest, GetBlobResponse>
    {
        private readonly BlobManager _blobManager;

        public BlobManagerHandler(BlobManager blobManager)
        {
            _blobManager = blobManager;
        }

        public async Task<GetBlobResponse> Handle(
            GetBlobRequest request,
            CancellationToken cancellationToken)
        {
            var blobList = await _blobManager.ListBlobsInContainerAsync();

            return new GetBlobResponse(BlobList: blobList);
        }
    }
}
