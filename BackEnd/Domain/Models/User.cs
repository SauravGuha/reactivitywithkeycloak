

namespace Domain.Models
{
    public class User : Base
    {
        public string KeycloakUserId { get; set; } = default!; // sub claim
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
    }
}