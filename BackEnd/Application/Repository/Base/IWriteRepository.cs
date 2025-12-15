
namespace Application.Repository.Base
{
    public interface IWriteRepository<T> where T :Domain.Models.Base
    {
        Task CreateAsync(T model, CancellationToken cancellationToken);

        Task UpdateAsync(T model, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
