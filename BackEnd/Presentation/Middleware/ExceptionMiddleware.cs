

using FluentValidation;

namespace Presentation.Middleware
{
    /// <summary>
    /// Centralised exception handler for every response
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException vex)
            {
                this.logger.LogError(vex.ToString());
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
            }
        }
    }
}