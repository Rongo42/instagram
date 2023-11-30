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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ApplicationDbContext _applicationDbContext;

        public UserController (IUserService userService, ApplicationDbContext applicationDbContext)
        {
            _userService = userService;
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpGet(nameof(GetUserById))]
        public IActionResult GetUserById(int id) 
        {
            var obj = _userService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpGet(nameof(GetAllUsers))]
        public IActionResult GetAllUsers() 
        {
            var obj = _userService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser(User user)
        {
            if (user != null)
            {
                _userService.Insert(user);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                _userService.Update(user);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(User user) 
        {
            if (user != null)
            {
                _userService.Delete(user);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpGet(nameof(GetUserInfo))]
        public IActionResult GetUserInfo(int id)
        {
            var obj = _userService.GetUserInfo(id);
            
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }


    }
}
