

using Application.Dtos;
using Application.Services.Base;

namespace Application.Services
{
    public interface IActivityReadService : IReadService<Domain.Models.Activity>
    {
        Task<IEnumerable<Domain.Models.Activity>> GetAllAsync(ActivityQuery activityQuery, CancellationToken cancellationToken);
    }
}
