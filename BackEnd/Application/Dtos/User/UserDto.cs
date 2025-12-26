

namespace Application.Dtos
{
    public class UserDto
    {
        public string KeycloakUserId { get; set; } = default!; // sub claim
        public string? DisplayName { get; set; }
        public string? Email { get; set; }

        public Guid Id { get; set; }
    }
}