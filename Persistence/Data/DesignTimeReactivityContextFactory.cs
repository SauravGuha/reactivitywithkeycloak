
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Data
{
    public class DesignTimeReactivityContextFactory : IDesignTimeDbContextFactory<ReactivityDbContext>
    {
        public ReactivityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReactivityDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=reactivitywithkeycloak;User Id=sa;Password=@Bcd.1234;TrustServerCertificate=True");
            return new ReactivityDbContext(optionsBuilder.Options);
        }
    }
}
