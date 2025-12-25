

using System.Linq.Expressions;
using Application.Dtos;
using Application.Services;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Service
{
    public class UserReadService : IUserReadService
    {
        private readonly ReactivityDbContext reactivityDbContext;

        public UserReadService(ReactivityDbContext reactivityDbContext)
        {
            this.reactivityDbContext = reactivityDbContext;
        }
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await reactivityDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var parameter = Expression.Parameter(typeof(User), "u");
            var defaultCondition = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            if (!string.IsNullOrWhiteSpace(userDto.KeycloakUserId))
            {
                var propertyExpression = Expression.PropertyOrField(parameter, nameof(User.KeycloakUserId));
                defaultCondition = Expression.AndAlso(defaultCondition, Expression.Equal(propertyExpression, Expression.Constant(userDto.KeycloakUserId)));
            }
            var lambda = Expression.Lambda<Func<User, bool>>(defaultCondition, [parameter]);

            return await reactivityDbContext.Users.Where(lambda).ToListAsync();
        }

        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return reactivityDbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
