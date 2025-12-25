

using Application.Dtos;
using Application.Services.Base;

namespace Application.Services
{
    public interface IUserReadService : IReadService<Domain.Models.User>
    {
        Task<IEnumerable<Domain.Models.User>> GetAllAsync(UserDto userDto, CancellationToken cancellationToken);
    }
}
