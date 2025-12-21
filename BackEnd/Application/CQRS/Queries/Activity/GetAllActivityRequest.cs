

using Application.Core;
using Application.Dtos;
using Application.Mapper.Activity;
using Application.Services;
using MediatR;

namespace Application.Queries.Activity
{
    public class GetAllActivityRequest : IRequest<Result<IEnumerable<ActivityDto>>>
    {
    }

    public class GetAllActivityRequestHandler : IRequestHandler<GetAllActivityRequest, Result<IEnumerable<ActivityDto>>>
    {
        private readonly IActivityReadService activityReadService;
        private readonly ActivityMapper activityMapper;

        public GetAllActivityRequestHandler(IActivityReadService activityReadService, ActivityMapper activityMapper)
        {
            this.activityReadService = activityReadService;
            this.activityMapper = activityMapper;
        }
        public async Task<Result<IEnumerable<ActivityDto>>> Handle(GetAllActivityRequest request, CancellationToken cancellationToken)
        {
            var result = await activityReadService.GetAllAsync(cancellationToken);
            return Result<IEnumerable<ActivityDto>>.SetSuccess(activityMapper.MapToDto(result));
        }
    }
}
