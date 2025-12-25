

namespace Presentation.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public static class MiddlewareRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMiddleWareService(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            services.AddScoped<UserRegistrationMiddleware>();
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAppMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
            return applicationBuilder;
        }
    }
}