

namespace Application.Dtos
{
    public class ActivityCommand
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public string City { get; set; } = null!;
        public string Venue { get; set; } = null!;

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public bool IsCancelled { get; set; }
    }
}
