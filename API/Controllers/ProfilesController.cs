using Application.Profiles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProfilesController : BaseApiController
    {
        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <returns></returns>
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new ProfileDetails.Query { Username = username }));
        }

    }
}
