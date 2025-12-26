

namespace Application.Dtos
{
    public class AttendeeDto
    {
        public required UserDto User { get; set; }

        public required ActivityDto ActivityDto { get; set; }
    }
}