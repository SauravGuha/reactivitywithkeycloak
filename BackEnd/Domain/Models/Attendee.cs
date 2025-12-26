

namespace Domain.Models
{
    public class Attendee : Base
    {
        public required Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public required Guid ActivityId { get; set; }

        public Activity Activity { get; set; } = null!;

        public bool IsHost { get; set; }

        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    }
}