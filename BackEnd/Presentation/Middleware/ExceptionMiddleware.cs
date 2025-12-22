

using System.Text.Json;
using System.Text.Json.Serialization;
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
                IEnumerable<object> errorMessage = new List<object> { new { App = vex.Message, vex.StackTrace } };
                var validationErrors = vex.Errors?.Select(e => (object)new { e.PropertyName, e.ErrorMessage });
                if (validationErrors != null)
                {
                    errorMessage = validationErrors;
                }
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(Result<object>.SetFailure(400, JsonSerializer.Serialize(errorMessage)));
                this.logger.LogError(vex.ToString());
            }
            catch (Exception ex)
            {
                IEnumerable<object> errorMessage = new List<object> { new { App = ex.Message, ex.StackTrace } };
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(Result<object>.SetFailure(400, JsonSerializer.Serialize(errorMessage)));
                this.logger.LogError(ex.ToString());
            }
        }
    }
}