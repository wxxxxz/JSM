using MediatR;

namespace JsonStorageManager.QueueProcessor.Models
{
    internal record ValidatorRequest(string Message) : IRequest<ValidatorResponse>;
}
