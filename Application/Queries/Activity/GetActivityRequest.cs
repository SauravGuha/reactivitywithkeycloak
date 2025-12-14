

using Application.Dtos;
using Application.Mapper.Activity;
using Application.Services;
using MediatR;

namespace Application.Queries.Activity
{
    public class GetActivityRequest : IRequest<ActivityDto>
    {
        public required Guid Id { get; set; }
    }

    public class GetActivityRequestHandler : IRequestHandler<GetActivityRequest, ActivityDto>
    {
        private readonly IActivityReadService activityReadService;
        private readonly ActivityMapper activityMapper;
        public GetActivityRequestHandler(IActivityReadService activityReadService, ActivityMapper activityMapper)
        {
            this.activityReadService = activityReadService;
            this.activityMapper = activityMapper;
        }
        public async Task<ActivityDto> Handle(GetActivityRequest request, CancellationToken cancellationToken)
        {
            var activity = await this.activityReadService.GetByIdAsync(request.Id, cancellationToken);
            if (activity == null)
            {
                throw new ArgumentOutOfRangeException("Activity not found.");
            }
            return this.activityMapper.MapToDto(activity);
        }
    }
}
