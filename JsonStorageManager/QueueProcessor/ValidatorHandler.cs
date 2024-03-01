using JsonStorageManager.QueueProcessor.Models;
using MediatR;

namespace JsonStorageManager.QueueProcessor
{
    internal class ValidatorHandler : IRequestHandler<ValidatorRequest, ValidatorResponse>
    {
        private readonly Validator _validator;

        public ValidatorHandler(Validator validator)
        {
            _validator = validator;
        }

        public Task<ValidatorResponse> Handle(
            ValidatorRequest request,
            CancellationToken cancellationToken)
        {
            var isValid = _validator.IsValid(request.Message);

            return Task.FromResult(new ValidatorResponse(IsValid: isValid));
        }
    }
}
