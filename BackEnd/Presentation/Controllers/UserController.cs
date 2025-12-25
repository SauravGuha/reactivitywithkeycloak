

using System.Security.Claims;
using Application.CQRS.Queries.User;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller for getting user info
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: nameof(GetUserInfo))]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserInfo(CancellationToken cancellationToken)
        {
            var user = this.HttpContext.User;
            var subClaim = user!.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrWhiteSpace(subClaim))
            {
                var result = await this.Mediator.Send(new GetUserInfoRequest
                {
                    UserDto = new Application.Dtos.UserDto
                    {
                        KeycloakUserId = subClaim
                    }
                }, cancellationToken);

                return base.ReturnResult(result);
            }
            return NotFound();
        }
    }
}