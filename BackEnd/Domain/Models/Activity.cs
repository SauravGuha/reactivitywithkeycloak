

namespace Domain.Models
{
    public class Activity : Base
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required DateTime EventDate { get; set; }
        public required string City { get; set; }
        public required string Venue { get; set; }

        public required long Latitude { get; set; }

        public required long Longitude { get; set; }

        public required bool IsCancelled { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; } = [];
    }
}
