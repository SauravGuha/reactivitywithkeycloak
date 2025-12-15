

using Application.Dtos;
using Application.Mapper.Activity;
using Application.Repository;
using Application.Services;
using MediatR;

namespace Application.Commands.Activity
{
    public class CreateActivityRequest : IRequest<ActivityDto>
    {
        public required ActivityCommand ActivityCommand { get; set; }
    }

    public class CreateActivityRequestHandler : IRequestHandler<CreateActivityRequest, ActivityDto>
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
        public async Task<ActivityDto> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
        {
            var query = activityMapper.MapToActivityQuery(request.ActivityCommand);
            var sameActivity = await activityReadService.GetAllAsync(query, cancellationToken);
            if(sameActivity.Any())
            {
                throw new ArgumentException("Activity with same title already exists.");
            }
            else
            {
                var activity = activityMapper.MapToActivity(request.ActivityCommand);
                if(activity != null)
                {
                    await this.activityWriteRepository.CreateAsync(activity, cancellationToken);
                    return this.activityMapper.MapToDto(activity);
                }
                else
                {
                    throw new NullReferenceException("Unable to create activity");
                }
            }
        }
    }
}
