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
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        private readonly ApplicationDbContext _applicationDbContext;

        public LikeController(ILikeService likeService, ApplicationDbContext applicationDbContext)
        {
            _likeService = likeService;
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpGet(nameof(GetLikeById))]
        public IActionResult GetLikeById(int Id)
        {
            var obj = _likeService.Get(Id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpGet(nameof(GetAllLikes))]
        public IActionResult GetAllLikes()
        {
            var obj = _likeService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpPost(nameof(LikeUnlike))]
        public IActionResult LikeUnlike(Like like) 
        {
            if (like != null)
            {
                _likeService.LikeUnlike(like);

                return Ok("Like action executed successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
