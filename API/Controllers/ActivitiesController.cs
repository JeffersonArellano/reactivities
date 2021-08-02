using Application.Activities;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <remarks>
        /// Return the list of registered activities
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <remarks>
        /// return a single activity by Id
        /// </remarks>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivities(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        /// <summary>
        /// Posts the specified activity model.
        /// </summary>
        /// <remarks>
        /// Creates a new Activity
        /// </remarks>
        /// <param name="activityModel">The activity model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActivityModel activityModel)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ActivityModel = activityModel }));
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="activityModel">The activity model.</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Put(Guid id, ActivityModel activityModel)
        {
            activityModel.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ActivityModel = activityModel }));
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
