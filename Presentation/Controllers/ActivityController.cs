
using Application.Commands.Activity;
using Application.Dtos;
using Application.Queries.Activity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// Controller for managing activities.
    /// </summary>
    public class ActivityController : BaseController
    {
        /// <summary>
        /// Gets all activities.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns> Returns a list of activities </returns>
        [HttpGet(Name = nameof(GetAllActivities))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllActivities(CancellationToken cancellationToken)
        {
            var query = new GetAllActivityRequest();
            var result = await this.Mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new activity.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Returns the created activity </returns>
        [HttpPost(Name = nameof(CreateActivity))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCommand request, 
            CancellationToken cancellationToken)
        {
            var createActivityRequest = new CreateActivityRequest
            {
                ActivityCommand = request
            };
            var result = await this.Mediator.Send(createActivityRequest, cancellationToken);
            return Ok(result);
        }

    }
}
