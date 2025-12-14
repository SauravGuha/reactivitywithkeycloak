

using Application.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repository
{
    public class ActivityRepository : IActivityWriteRepository
    {
        private readonly ReactivityDbContext reactivityDbContext;

        public ActivityRepository(ReactivityDbContext reactivityDbContext)
        {
            this.reactivityDbContext = reactivityDbContext;
        }

        public async Task CreateAsync(Activity model, CancellationToken cancellationToken)
        {
            await reactivityDbContext.Activities.AddAsync(model, cancellationToken);
            await reactivityDbContext.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return reactivityDbContext.Activities
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task UpdateAsync(Activity model, CancellationToken cancellationToken)
        {
            var result = reactivityDbContext.Activities.Update(model);
            await reactivityDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
