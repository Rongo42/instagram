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
    public class AccountController : ControllerBase
    {
        private readonly ICustomService<Account> _customService;

        private readonly ApplicationDbContext _applicationDbContext;

        public AccountController(ICustomService<Account> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetAccountById))]
        public IActionResult GetAccountById(int id)
        {
            var obj = _customService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpGet(nameof(GetAllAccounts))]
        public IActionResult GetAllAccounts()
        {
            var obj = _customService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpPost(nameof(CreateAccount))]
        public IActionResult CreateAccount(Account account)
        {
            if (account != null)
            {
                _customService.Insert(account);
                return Ok("Created successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost(nameof(UpdateAccount))]
        public IActionResult UpdateAccount(Account account)
        {
            if (account != null)
            {
                _customService.Update(account);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(nameof(DeleteAccount))]
        public IActionResult DeleteAccount(Account account)
        {
            if (account != null)
            {
                _customService.Delete(account);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
