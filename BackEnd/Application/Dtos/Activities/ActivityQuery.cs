

namespace Application.Dtos
{
    public class ActivityQuery
    {
        public string? Title { get; set; }
        public string? Category { get; set; }
        public DateTime? EventDate { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}
