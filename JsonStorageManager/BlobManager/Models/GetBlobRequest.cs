using MediatR;

namespace JsonStorageManager.BlobManager.Models
{
    internal record GetBlobRequest() : IRequest<GetBlobResponse>;
}
