
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
        [HttpGet(template:nameof(GetAllActivities))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllActivities(CancellationToken cancellationToken)
        {
            var query = new GetAllActivityRequest();
            var result = await this.Mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        /// <summary>
        /// Gets an activity by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(template: nameof(GetActivityById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetActivityById([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Activity ID is required.");
            }
            var query = new GetActivityRequest { Id = id };
            var result = await this.Mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        /// <summary>
        /// Creates a new activity.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Returns the created activity </returns>
        [HttpPost(template:nameof(CreateActivity))]
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


        /// <summary>
        /// Updates an existing activity.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut(template: nameof(UpdateActivity))]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateActivity([FromBody] UpdateActivityRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return BadRequest("Activity ID is required for update.");
            }
            var updateActivityRequest = new UpdateActivityRequest
            {
                Id = request.Id,
                ActivityCommand = request.ActivityCommand
            };
            var result = await this.Mediator.Send(updateActivityRequest, cancellationToken);
            return Ok(result);
        }

    }
}
