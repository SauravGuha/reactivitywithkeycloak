

using Application.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.Mapper.Activity
{
    [Mapper]
    public partial class UserMapper
    {
        public partial UserDto MapToUserDto(Domain.Models.User user);

        public partial Domain.Models.User MapToUser(UserDto userDto);
    }
}
