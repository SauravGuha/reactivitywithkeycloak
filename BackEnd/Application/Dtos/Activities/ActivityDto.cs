

namespace Application.Dtos
{
    public class ActivityDto
    {
        public required Guid Id { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required DateTime EventDate { get; set; }
        public required string City { get; set; }
        public required string Venue { get; set; }

        public required long Latitude { get; set; }

        public required long Longitude { get; set; }

        public required bool IsCancelled { get; set; }

        public string? HostDisplayName { get; set; }

        public string? HostId { get; set; }

        public IEnumerable<UserDto> Attendees { get; set; } = [];
    }
}
