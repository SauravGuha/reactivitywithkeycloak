
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
        [HttpGet(template: nameof(GetAllActivities))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllActivities(CancellationToken cancellationToken)
        {
            var query = new GetAllActivityRequest();
            var result = await this.Mediator.Send(query, cancellationToken);
            return this.ReturnResult(result);
        }


        /// <summary>
        /// Gets an activity by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(template: nameof(GetActivityById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetActivityById([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Activity ID is required.");
            }
            var query = new GetActivityRequest { Id = id };
            var result = await this.Mediator.Send(query, cancellationToken);
            return this.ReturnResult(result);
        }


        /// <summary>
        /// Creates a new activity.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> Returns the created activity </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCommand request,
            CancellationToken cancellationToken)
        {
            var createActivityRequest = new CreateActivityRequest
            {
                ActivityCommand = request
            };
            var result = await this.Mediator.Send(createActivityRequest, cancellationToken);
            return this.ReturnResult(result);
        }

        /// <summary>
        /// Updates an existing activity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateActivity([FromQuery] Guid id, [FromBody] ActivityCommand request,
            CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Activity ID is required for update.");
            }
            var updateActivityRequest = new UpdateActivityRequest
            {
                Id = id,
                ActivityCommand = request
            };
            var result = await this.Mediator.Send(updateActivityRequest, cancellationToken);
            return this.ReturnResult(result);
        }


        /// <summary>
        /// Deletes an activity by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteActivity(Guid id, CancellationToken cancellationToken)
        {
            await this.Mediator.Send(new DeleteActivityRequest { Id = id }, cancellationToken);
            return NoContent();

        }
    }
}
