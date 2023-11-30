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

        private readonly ApplicationDbContext _applicationDbContext;

        public FollowsController(IFollowsService followsService, ApplicationDbContext applicationDbContext)
        {
            _followsService = followsService;
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpPost(nameof(FollowUnfollow))]
        public IActionResult FollowUnfollow(User follower, User followed)
        {
            if (follower != null && followed != null) 
            {
                _followsService.FollowUnfollow(follower, followed);

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
