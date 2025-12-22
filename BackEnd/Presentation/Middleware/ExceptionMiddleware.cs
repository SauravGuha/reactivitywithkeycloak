

using System.Text.Json;
using Application.Core;
using FluentValidation;

namespace Presentation.Middleware
{
    /// <summary>
    /// Centralised exception handler for every response
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
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
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException vex)
            {
                var validationErrors = vex.Errors?.Select(e => (object)new { e.PropertyName, e.ErrorMessage });
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(Result<object>.SetFailure(400, vex.Message, JsonSerializer.Serialize(validationErrors)));
                this.logger.LogError(vex.ToString());
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(Result<object>.SetFailure(500, ex.Message, ex.StackTrace));
                this.logger.LogError(ex.ToString());
            }
        }
    }
}