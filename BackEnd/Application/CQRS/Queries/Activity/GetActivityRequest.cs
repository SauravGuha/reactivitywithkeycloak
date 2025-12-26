

using Application.Core;
using Application.Dtos;
using Application.Mapper.Activity;
using Application.Services;
using MediatR;

namespace Application.Queries.Activity
{
    public class GetActivityRequest : IRequest<Result<ActivityDto>>
    {
        public required Guid Id { get; set; }
    }

    public class GetActivityRequestHandler : IRequestHandler<GetActivityRequest, Result<ActivityDto>>
    {
        private readonly IActivityReadService activityReadService;
        private readonly ActivityMapper activityMapper;
        public GetActivityRequestHandler(IActivityReadService activityReadService, ActivityMapper activityMapper)
        {
            this.activityReadService = activityReadService;
            this.activityMapper = activityMapper;
        }
        public async Task<Result<ActivityDto>> Handle(GetActivityRequest request, CancellationToken cancellationToken)
        {
            var activity = await this.activityReadService.GetByIdAsync(request.Id, cancellationToken);
            if (activity == null)
            {
                return Result<ActivityDto>.SetFailure(404, "Acitivty not found", null);
            }
            return Result<ActivityDto>.SetSuccess(this.activityMapper.MapToActivityDto(activity));
        }
    }
}
