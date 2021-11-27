using Application.Followers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class FollowController : BaseApiController
    {
        /// <summary>
        /// Follows the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        [HttpPost("{username}")]
        public async Task<IActionResult> Follow(string username)
        {
            return HandleResult(await Mediator.Send(new FollowToggle.Command { TargetUsername = username }));
        }

        /// <summary>
        /// Followerses the list.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        [HttpGet("{username}")]
        public async Task<IActionResult> FollowersList(string username, string predicate)
        {
            return HandleResult(await Mediator.Send(new FollowersList.Query { Predicate = predicate, UserName = username }));
        }
    }
}
