

namespace Presentation.Middleware
{
    public static class MiddlewareRegistration
    {
        public static IServiceCollection AddMiddleWareService(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseAppMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
            return applicationBuilder;
        }
    }
}