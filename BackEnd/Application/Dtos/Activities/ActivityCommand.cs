

namespace Application.Dtos
{
    /// <summary>
    /// Validations are handled by the validator
    /// </summary>
    public class ActivityCommand
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime EventDate { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public bool IsCancelled { get; set; }
    }
}
