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
        private readonly ICustomService<Like> _customService;

        private readonly ApplicationDbContext _applicationDbContext;

        public LikeController(ICustomService<Like> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpGet(nameof(GetLikeById))]
        public IActionResult GetLikeById(int Id)
        {
            var obj = _customService.Get(Id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpGet(nameof(GetAllLikes))]
        public IActionResult GetAllLikes()
        {
            var obj = _customService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpPost(nameof(LikeUnlike))]
        public IActionResult LikeUnlike(Like like) 
        {
            var obj = _customService.Get(like.Id);

            if (obj == null)
            {
                _customService.Insert(like);
                return Ok("Liked succesfully");
            }
            else
            {
                _customService.Delete(like);
                return Ok("Unliked succesfully");
            }
        }

    }
}
