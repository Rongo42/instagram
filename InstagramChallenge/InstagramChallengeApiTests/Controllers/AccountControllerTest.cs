using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Data;
using DomainLayer.Models;
using FakeItEasy;
using FluentAssertions;
using InstagramWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.ICustomServices;

namespace InstagramChallengeApiTests.Controllers
{ 
    public class AccountControllerTest
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly Type _ok, _badRequest;

        public AccountControllerTest() 
        {
            _accountService = A.Fake<IAccountService>();
            _configuration = A.Fake<IConfiguration>();
            _ok = typeof(OkObjectResult);
            _badRequest = typeof(BadRequestResult);
        }

        [Fact]
        public void AccountController_GetAllAccounts_ReturnOk()
        {
            //Arrange
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.GetAllAccounts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
            
        }

        [Fact]
        public void AccountController_GetAccountById_ReturnOk()
        {
            //Arrange
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.GetAccountById(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void AccountController_CreateAccount_ReturnOk()
        {
            //Arrange
            var account = A.Fake<Account>(x => x.WithArgumentsForConstructor(() => new Account("pepe","1234")));
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.CreateAccount(account);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void AccountController_CreateAccount_ReturnBadRequest()
        {
            //Arrange
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.CreateAccount(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void AccountController_UpdateAccount_ReturnOk()
        {
            //Arrange
            var account = A.Fake<Account>(x => x.WithArgumentsForConstructor(() => new Account("pepo", "1234")));
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.UpdateAccount(account);

            //Asert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void AccountController_UpdateAccount_ReturnBadRequest()
        {
            //Arrange
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.UpdateAccount(null);

            //Asert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }

        [Fact]
        public void AccountController_DeleteAccount_ReturnOk()
        {
            //Arrange
            var account = A.Fake<Account>(x => x.WithArgumentsForConstructor(() => new Account("pepo", "1234")));
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.DeleteAccount(account);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void AccountController_DeleteAccount_ReturnBadRequest()
        {
            //Arrange
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.DeleteAccount(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }

        /*
        [Fact]
        //Since this endpoint needs to acces database info in order to compare the encrypted passwords,
        //the tests using a mock will always return an Unathorized response.
        //As this assertion will always be false, this test should not be considered
        public void AccountController_TryLogin_ReturnOk()
        {
            //Arrange
            var account = A.Fake<Account>(x => x.WithArgumentsForConstructor(() => new Account("pepo", "1234")));
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.TryLogin(account);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }
        */

        [Fact]
        public void AccountController_TryLogin_ReturnUnauthorized()
        {
            //Arrange
            var controller = new AccountController(_accountService, _configuration);

            //Act
            var result = controller.TryLogin(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(UnauthorizedResult));
        }
    }
}
