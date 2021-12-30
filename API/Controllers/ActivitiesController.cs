using Application.Activities;
using Application.Core;
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
        public async Task<IActionResult> GetActivities([FromQuery] ActivityParams pagingParams)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = pagingParams }));
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
        public async Task<IActionResult> Post([FromBody] Activity activityModel)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activityModel }));
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="activityModel">The activity model.</param>
        /// <returns></returns>
        [Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Activity activityModel)
        {
            activityModel.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ActivityModel = activityModel }));
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Authorize(Policy = "IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        /// <summary>
        /// Attends the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
        }
    }
}
