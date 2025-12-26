

using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.Mapper.Activity
{
    [Mapper]
    public partial class ActivityMapper
    {
        private UserMapper userMapper = new UserMapper();

        [MapProperty(source: nameof(Domain.Models.Activity.Attendees),
        target: nameof(ActivityDto.Attendees),
        Use = nameof(MapActivityAttendees))]
        [MapProperty(
    source: nameof(Domain.Models.Activity.Attendees),
    target: nameof(ActivityDto.HostId),
    Use = nameof(MapHostId))]
        [MapProperty(
    source: nameof(Domain.Models.Activity.Attendees),
    target: nameof(ActivityDto.HostDisplayName),
    Use = nameof(MapHostName))]
        public partial ActivityDto MapToActivityDto(Domain.Models.Activity activity);

        public partial IEnumerable<ActivityDto> MapToListOfActivityDto(IEnumerable<Domain.Models.Activity> activity);

        public partial ActivityQuery MapToActivityQuery(ActivityCommand activityDto);

        public partial Domain.Models.Activity MapToActivity(ActivityCommand activityDto);

        public partial void UpdateActivityFromCommand(ActivityCommand activityCommand, Domain.Models.Activity activity);

        private IEnumerable<UserDto> MapActivityAttendees(IEnumerable<Domain.Models.Attendee> attendees)
        => attendees
        .Select(a => userMapper.MapToUserDto(a.User));

        private string MapHostId(IEnumerable<Domain.Models.Attendee> attendees)
        => attendees
        .Where(a => a.IsHost)
        .Select(a => a.User.KeycloakUserId)
        .FirstOrDefault() ?? string.Empty;

        private string MapHostName(IEnumerable<Domain.Models.Attendee> attendees)
            => attendees
                .Where(a => a.IsHost)
                .Select(a => a.User.DisplayName)
                .FirstOrDefault() ?? string.Empty;
    }
}
