

using Application.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repository
{
    public class UserRepository : IUserWriteRepository
    {
        private readonly ReactivityDbContext reactivityDbContext;

        public UserRepository(ReactivityDbContext reactivityDbContext)
        {
            this.reactivityDbContext = reactivityDbContext;
        }

        public async Task CreateAsync(User model, CancellationToken cancellationToken)
        {
            await reactivityDbContext.Users.AddAsync(model, cancellationToken);
            await reactivityDbContext.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return reactivityDbContext.Users
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task UpdateAsync(User model, CancellationToken cancellationToken)
        {
            var result = reactivityDbContext.Users.Update(model);
            await reactivityDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
