using Application.Dtos;

namespace Application.Services.Base
{
    public interface IReadService<T> where T : Domain.Models.Base
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(ActivityQuery activityQuery, CancellationToken cancellationToken);
    }
}
