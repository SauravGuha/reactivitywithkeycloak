

using Application.Dtos;
using Application.Services;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

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

        public async Task<IEnumerable<Activity>> GetAllAsync(ActivityQuery activityQuery, CancellationToken cancellationToken)
        {
            var query = reactivityDbContext.Activities.AsQueryable();
            if(activityQuery.City is not null)
            {
                query = query.Where(x => x.City == activityQuery.City);
            }
            if(activityQuery.Category is not null)
            {
                query = query.Where(x => x.Category == activityQuery.Category);
            }
            if(activityQuery.Venue is not null)
            {
                query = query.Where(x => x.Category == activityQuery.Category);
            }
            if (activityQuery.Title is not null)
            {
                query = query.Where(x => x.Title == activityQuery.Title);
            }
            if (activityQuery.EventDate is not null)
            {
                query = query.Where(x => x.EventDate == activityQuery.EventDate);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public Task<Activity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return reactivityDbContext.Activities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
