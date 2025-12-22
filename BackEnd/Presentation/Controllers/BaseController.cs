using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;
        /// <summary>
        /// 
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public IActionResult ReturnResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                var erroCode = result.ErrorCode;
                switch (erroCode)
                {
                    case 400:
                        return BadRequest(result);
                    case 404:
                        return NotFound(result);
                    case 409:
                        return Conflict(result);
                    default:
                        return UnprocessableEntity(result);
                }
            }
        }
    }
}
