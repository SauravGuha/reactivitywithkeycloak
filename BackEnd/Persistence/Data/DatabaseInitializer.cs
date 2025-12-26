

using System.Threading.Tasks;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Data
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                var context = scopedProvider.GetRequiredService<ReactivityDbContext>();
                if (!context.Activities.Any())
                {
                    context.Activities.AddRange(new[]
                    {
                    new Domain.Models.Activity
                    {
                        Title = "Past Activity 1",
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        EventDate = DateTime.UtcNow.AddMonths(-2),
                        City = "London",
                        Venue = "Pub",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Past Activity 2",
                        Description = "Activity 1 month ago",
                        Category = "music",
                        EventDate = DateTime.UtcNow.AddMonths(-1),
                        City = "Paris",
                        Venue = "Louvre",
                        Latitude = 48,
                        Longitude = 2,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Id=Guid.Parse("A3AB383B-B3C0-4D0F-A2E3-45E74009D87E"),
                        Title = "Future Activity 1",
                        Description = "Activity 1 month in future",
                        Category = "travel",
                        EventDate = DateTime.UtcNow.AddMonths(1),
                        City = "London",
                        Venue = "Natural History Museum",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Future Activity 2",
                        Description = "Activity 2 months in future",
                        Category = "film",
                        EventDate = DateTime.UtcNow.AddMonths(2),
                        City = "London",
                        Venue = "Cinema",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Future Activity 3",
                        Description = "Activity 3 months in future",
                        Category = "food",
                        EventDate = DateTime.UtcNow.AddMonths(3),
                        City = "London",
                        Venue = "Restaurant",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Future Activity 4",
                        Description = "Activity 4 months in future",
                        Category = "drinks",
                        EventDate = DateTime.UtcNow.AddMonths(4),
                        City = "London",
                        Venue = "Another pub",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Future Activity 5",
                        Description = "Activity 5 months in future",
                        Category = "music",
                        EventDate = DateTime.UtcNow.AddMonths(5),
                        City = "London",
                        Venue = "O2 Arena",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Future Activity 6",
                        Description = "Activity 6 months in future",
                        Category = "travel",
                        EventDate = DateTime.UtcNow.AddMonths(6),
                        City = "London",
                        Venue = "Somewhere on the Thames",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                    new Domain.Models.Activity
                    {
                        Title = "Future Activity 7",
                        Description = "Activity 7 months in future",
                        Category = "film",
                        EventDate = DateTime.UtcNow.AddMonths(7),
                        City = "London",
                        Venue = "Cinema",
                        Latitude = 51,
                        Longitude = 0,
                        IsCancelled = false
                    },
                });

                    context.SaveChanges();
                }
                if (!context.Attendees.Any())
                {
                    context.Attendees.AddRange(new[]
                    {
                            new Attendee
                            {
                                UserId = Guid.Parse("30F2E7F2-B511-4B4A-2A2C-08DE438D349C"),
                                ActivityId = Guid.Parse("A3AB383B-B3C0-4D0F-A2E3-45E74009D87E"),
                                IsHost = true,
                                DateJoined = DateTime.UtcNow
                            },
                            new Attendee
                            {
                                UserId = Guid.Parse("30F2E7F2-B511-4B4A-2A2C-08DE438D349C"),
                                ActivityId = Guid.Parse("07B51E09-EA31-46B2-A9D8-31D729F221E1"),
                                IsHost = false,
                                DateJoined = DateTime.UtcNow
                            }
                    });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
