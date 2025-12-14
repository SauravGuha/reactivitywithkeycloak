

using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.Mapper.Activity
{
    [Mapper]
    public partial class ActivityMapper
    {
        public partial ActivityDto MapToDto(Domain.Models.Activity activity);

        public partial IEnumerable<ActivityDto> MapToDto(IEnumerable<Domain.Models.Activity> activity);

        public partial ActivityQuery MapToActivityQuery(ActivityCommand activityDto);

        public partial Domain.Models.Activity MapToActivity(ActivityCommand activityDto);
    }
}
