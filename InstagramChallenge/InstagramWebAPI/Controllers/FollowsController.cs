using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;

namespace InstagramWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IFollowsService _followsService;

        public FollowsController(IFollowsService followsService)
        {
            _followsService = followsService;
        }

        [Authorize]
        [HttpPost(nameof(FollowUnfollow))]
        public IActionResult FollowUnfollow(int followerid, int followedid)
        {
            if (followerid > 0 && followedid > 0) 
            {
                _followsService.FollowUnfollow(followerid, followedid);

                return Ok("Following action executed successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpGet(nameof(GetFollowersByUserId))]
        public IActionResult GetFollowersByUserId(int Id)
        {
            var obj = _followsService.GetFollowersByUserId(Id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

    }
}
