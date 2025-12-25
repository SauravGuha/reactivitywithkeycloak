


using System.Security.Claims;
using Application.Commands.Activity;
using MediatR;

namespace Presentation.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRegistrationMiddleware : IMiddleware
    {
        private readonly IMediator mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UserRegistrationMiddleware(IMediator mediator)
        {
            this.mediator = mediator;
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
            var identity = context.User?.Identity;
            if (identity != null && identity.IsAuthenticated)
            {
                var subClaim = context.User!.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var email = context.User!.FindFirst(ClaimTypes.Email)?.Value;
                var displayName = context.User!.FindFirst("name")?.Value;
                if (!string.IsNullOrWhiteSpace(subClaim))
                    await this.mediator.Send(new CreateUserRequest
                    {
                        UserCommand = new Application.Dtos.UserDto
                        {
                            DisplayName = displayName,
                            Email = email,
                            KeycloakUserId = subClaim
                        }
                    }, context.RequestAborted);
            }

            await next(context);
        }
    }
}