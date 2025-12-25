

using Application.Repository;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repository;
using Persistence.Service;

namespace Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your persistence services here    
            services.AddDbContext<ReactivityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Persistence"));
            });
            services.AddScoped<IActivityWriteRepository, ActivityRepository>();
            services.AddScoped<IActivityReadService, ActivityReadService>();
            services.AddScoped<IUserWriteRepository, UserRepository>();
            services.AddScoped<IUserReadService, UserReadService>();
            return services;
        }

        public static void InitializePersistence(this IServiceProvider serviceProvider)
        {
            DatabaseInitializer.InitializeDatabase(serviceProvider);
        }
    }
}
