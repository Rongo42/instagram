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
    public class UserController : ControllerBase
    {
        private readonly ICustomService<User> _customService;

        private readonly ApplicationDbContext _applicationDbContext;

        public UserController (ICustomService<User> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetUserById))]
        public IActionResult GetUserById(int id) 
        {
            var obj = _customService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpGet(nameof(GetAllUsers))]
        public IActionResult GetAllUsers() 
        {
            var obj = _customService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser(User user)
        {
            if (user != null)
            {
                _customService.Insert(user);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                _customService.Update(user);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(User user) 
        {
            if (user != null)
            {
                _customService.Delete(user);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }


    }
}
