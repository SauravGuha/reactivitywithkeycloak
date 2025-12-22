

using Application.Core;
using Application.Dtos;
using Application.Mapper.Activity;
using Application.Repository;
using Application.Services;
using MediatR;

namespace Application.Commands.Activity
{
    public class CreateActivityRequest : IRequest<Result<ActivityDto>>
    {
        public required ActivityCommand ActivityCommand { get; set; }
    }

    public class CreateActivityRequestHandler : IRequestHandler<CreateActivityRequest, Result<ActivityDto>>
    {
        private readonly IActivityWriteRepository activityWriteRepository;
        private readonly IActivityReadService activityReadService;
        private readonly ActivityMapper activityMapper;

        public CreateActivityRequestHandler(IActivityWriteRepository activityWriteRepository,
            IActivityReadService activityReadService, ActivityMapper activityMapper)
        {
            this.activityWriteRepository = activityWriteRepository;
            this.activityReadService = activityReadService;
            this.activityMapper = activityMapper;
        }
        public async Task<Result<ActivityDto>> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
        {
            var query = activityMapper.MapToActivityQuery(request.ActivityCommand);
            var sameActivity = await activityReadService.GetAllAsync(query, cancellationToken);
            if (sameActivity.Any())
            {
                return Result<ActivityDto>.SetFailure(409, "Cannot create duplicate activity", null);
            }
            else
            {
                var activity = activityMapper.MapToActivity(request.ActivityCommand);
                if (activity != null)
                {
                    await this.activityWriteRepository.CreateAsync(activity, cancellationToken);
                    return Result<ActivityDto>.SetSuccess(this.activityMapper.MapToDto(activity));
                }
                else
                {
                    return Result<ActivityDto>.SetFailure(422, "Unable to create activity", "MapToActivity to returned null");
                }
            }
        }
    }
}
