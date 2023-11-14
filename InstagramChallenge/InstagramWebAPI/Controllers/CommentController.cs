using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;

namespace InstagramWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICustomService<Comment> _customService;

        private readonly ApplicationDbContext _applicationDbContext;

        public CommentController(ICustomService<Comment> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetCommentById))]
        public IActionResult GetCommentById(int id)
        {
            var obj = _customService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpGet(nameof(GetAllComments))]
        public IActionResult GetAllComments()
        {
            var obj = _customService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpPost(nameof(CreateComment))]
        public IActionResult CreateComment(Comment comment)
        {
            if (comment != null)
            {
                _customService.Insert(comment);
                return Ok("Created successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost(nameof(UpdateComment))]
        public IActionResult UpdateComment(Comment comment)
        {
            if (comment != null)
            {
                _customService.Update(comment);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(nameof(DeleteComment))]
        public IActionResult DeleteComment(Comment comment)
        {
            if (comment != null)
            {
                _customService.Delete(comment);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
