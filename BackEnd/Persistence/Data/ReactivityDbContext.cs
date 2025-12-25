using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ReactivityDbContext : DbContext
    {
        public ReactivityDbContext(DbContextOptions<ReactivityDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
