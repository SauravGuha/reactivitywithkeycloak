

using Application.Mapper.Activity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Mapper
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddMapperServices(this IServiceCollection services)
        {
            services.AddScoped<ActivityMapper>();
            return services;
        }
    }
}
