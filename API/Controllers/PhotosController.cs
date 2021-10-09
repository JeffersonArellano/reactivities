using Application.Photos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Photos Controller
    /// </summary>
    /// <seealso cref="API.Controllers.BaseApiController" />
    public class PhotosController : BaseApiController
    {
        /// <summary>
        /// Adds the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddPhoto.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new DeletePhoto.Command { Id = id }));
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMain(string id)
        {
            return HandleResult(await Mediator.Send(new SetMain.Command { Id = id }));
        }
    }
}
