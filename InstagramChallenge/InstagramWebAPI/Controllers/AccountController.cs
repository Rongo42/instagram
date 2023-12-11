using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InstagramWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        private readonly IConfiguration _config;

        public AccountController(IAccountService accountService, IConfiguration config)
        {
            _accountService = accountService;
            _config = config;
        }

        [Authorize]
        [HttpGet(nameof(GetAccountById))]
        public IActionResult GetAccountById(int id)
        {
            var obj = _accountService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [HttpGet(nameof(GetAllAccounts))]
        public IActionResult GetAllAccounts()
        {
            var obj = _accountService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [AllowAnonymous]
        [HttpPost(nameof(CreateAccount))]
        public IActionResult CreateAccount(Account account)
        {
            if (account != null)
            {
                _accountService.Insert(account);
                return Ok("Created successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpPost(nameof(UpdateAccount))]
        public IActionResult UpdateAccount(Account account)
        {
            if (account != null)
            {
                _accountService.Update(account);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete(nameof(DeleteAccount))]
        public IActionResult DeleteAccount(Account account)
        {
            
            if (account != null)
            {
                _accountService.Delete(account);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost(nameof(TryLogin))]
        public IActionResult TryLogin(Account account)
        {
            if (_accountService.TryLogin(account, out var verifiedAccount))
            {
                return Ok(new { token = GenerateJSONWebToken(verifiedAccount) });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJSONWebToken(Account userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
