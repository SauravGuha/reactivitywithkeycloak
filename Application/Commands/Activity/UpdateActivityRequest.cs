

using Application.Dtos;
using Application.Mapper.Activity;
using Application.Repository;
using Application.Services;
using MediatR;

namespace Application.Commands.Activity
{
    public class UpdateActivityRequest :IRequest<ActivityDto>
    {
        public required Guid Id { get; set; }
        public required ActivityCommand ActivityCommand { get; set; }
    }

    public class UpdateActivityRequestHandler : IRequestHandler<UpdateActivityRequest, ActivityDto>
    {
        private readonly IActivityWriteRepository activityWriteRepository;
        private readonly IActivityReadService activityReadService;
        private readonly ActivityMapper activityMapper;

        public UpdateActivityRequestHandler(IActivityWriteRepository activityWriteRepository,
            IActivityReadService activityReadService, ActivityMapper activityMapper)
        {
            this.activityWriteRepository = activityWriteRepository;
            this.activityReadService = activityReadService;
            this.activityMapper = activityMapper;
        }

        public async Task<ActivityDto> Handle(UpdateActivityRequest request, CancellationToken cancellationToken)
        {
            var activity = await this.activityReadService.GetByIdAsync(request.Id, cancellationToken);
            if (activity == null)
            {
                throw new ArgumentOutOfRangeException("Activity not found.");
            }
            else
            {
                activityMapper.UpdateActivityFromCommand(request.ActivityCommand, activity);
                await this.activityWriteRepository.UpdateAsync(activity, cancellationToken);
                return this.activityMapper.MapToDto(activity);
            }
        }
    }
}
