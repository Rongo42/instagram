using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;

namespace InstagramWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ICustomService<Post> _customService;

        private readonly ApplicationDbContext _applicationDbContext;

        public PostController (ICustomService<Post> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpGet(nameof(GetPostById))]
        public IActionResult GetPostById(int id) 
        {
            var obj = _customService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpGet(nameof(GetAllPosts))]
        public IActionResult GetAllPosts()
        {
            var obj = _customService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpPost(nameof(CreatePost))]
        public IActionResult CreatePost(Post post)
        {
            if (post != null)
            {
                _customService.Insert(post);
                return Ok("Created successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpPost(nameof(UpdatePost))]
        public IActionResult UpdatePost(Post post)
        {
            if (post != null)
            {
                _customService.Update(post);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete(nameof(DeletePost))]
        public IActionResult DeletePost(Post post) 
        {
            if (post != null)
            {
                _customService.Delete(post);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
