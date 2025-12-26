

using Application.Dtos;
using Application.Services;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Linq.Expressions;

namespace Persistence.Service
{
    public class ActivityReadService : IActivityReadService
    {
        private readonly ReactivityDbContext reactivityDbContext;

        public ActivityReadService(ReactivityDbContext reactivityDbContext)
        {
            this.reactivityDbContext = reactivityDbContext;
        }
        public async Task<IEnumerable<Activity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await reactivityDbContext.Activities.ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllAsync(ActivityQuery activityQuery, CancellationToken cancellationToken, params string[] navigationProps)
        {
            var parameter = Expression.Parameter(typeof(Activity), "a");
            var defaultConstant = Expression.Constant(1, typeof(int));
            var binaryExpression = Expression.Equal(defaultConstant, defaultConstant);

            if (activityQuery != null)
            {
                if (activityQuery.City is not null)
                {
                    var propertyExpression = Expression.Property(parameter, nameof(Activity.City));
                    var propertyConstant = Expression.Constant(activityQuery.City, typeof(string));
                    binaryExpression = Expression.AndAlso(binaryExpression, Expression.Equal(propertyExpression, propertyConstant));
                }
                if (activityQuery.Category is not null)
                {
                    var propertyExpression = Expression.Property(parameter, nameof(Activity.Category));
                    var propertyConstant = Expression.Constant(activityQuery.Category, typeof(string));
                    binaryExpression = Expression.AndAlso(binaryExpression, Expression.Equal(propertyExpression, propertyConstant));
                }
                if (activityQuery.Venue is not null)
                {
                    var propertyExpression = Expression.Property(parameter, nameof(Activity.Venue));
                    var propertyConstant = Expression.Constant(activityQuery.Venue, typeof(string));
                    binaryExpression = Expression.AndAlso(binaryExpression, Expression.Equal(propertyExpression, propertyConstant));
                }
                if (activityQuery.Title is not null)
                {
                    var propertyExpression = Expression.Property(parameter, nameof(Activity.Title));
                    var propertyConstant = Expression.Constant(activityQuery.Title, typeof(string));
                    binaryExpression = Expression.AndAlso(binaryExpression, Expression.Equal(propertyExpression, propertyConstant));
                }
                if (activityQuery.EventDate is not null)
                {
                    var propertyExpression = Expression.Property(parameter, nameof(Activity.EventDate));
                    var propertyConstant = Expression.Constant(activityQuery.EventDate ?? DateTime.MinValue, typeof(DateTime));
                    binaryExpression = Expression.AndAlso(binaryExpression, Expression.Equal(propertyExpression, propertyConstant));
                }
            }
            var expresssion = Expression.Lambda<Func<Activity, bool>>(binaryExpression, [parameter]);
            var query = reactivityDbContext.Activities.Where(expresssion).AsQueryable();
            foreach (var prop in navigationProps)
            {
                query = query.Include(prop);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public Task<Activity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return reactivityDbContext.Activities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
