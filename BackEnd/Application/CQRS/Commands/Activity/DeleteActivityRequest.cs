
using Application.Repository;
using MediatR;

namespace Application.Commands.Activity
{
    public class DeleteActivityRequest : IRequest<Unit>
    {
        public required Guid Id { get; set; }
    }

    public class DeleteActivityRequestHandler : IRequestHandler<DeleteActivityRequest, Unit>
    {
        private readonly IActivityWriteRepository activityWriteRepository;

        public DeleteActivityRequestHandler(IActivityWriteRepository activityWriteRepository)
        {
            this.activityWriteRepository = activityWriteRepository;
        }
        public async Task<Unit> Handle(DeleteActivityRequest request, CancellationToken cancellationToken)
        {
            await this.activityWriteRepository.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
