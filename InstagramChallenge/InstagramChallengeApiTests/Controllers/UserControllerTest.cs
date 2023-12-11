using DomainLayer.Models;
using FakeItEasy;
using FluentAssertions;
using InstagramWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramChallengeApiTests.Controllers
{
    public class UserControllerTest
    {
        private readonly IUserService _userService;
        private readonly Type _ok;
        private readonly Type _notFound;
        private readonly Type _badRequest;

        public UserControllerTest()
        {
            _userService = A.Fake<IUserService>();
            _ok = typeof(OkObjectResult);
            _notFound = typeof(NotFoundObjectResult);
            _badRequest = typeof(BadRequestResult);
        }

        [Fact]
        public void UserController_GetUserById_ReturnOk()
        {
            //Arrange
            var controller = new UserController(_userService);

            //Act
            var result = controller.GetUserById(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void UserController_GetAllUsers_ReturnOk()
        {
            //Arrange
            var controller = new UserController(_userService);

            //Act
            var result = controller.GetAllUsers();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void UserController_CreateUser_ReturnOk()
        {
            //Arrange
            var user = A.Fake<User>();
            var controller = new UserController(_userService);

            //Act
            var result = controller.CreateUser(user);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void UserController_CreateUser_ReturnBadRequest()
        {
            //Arrange
            var controller = new UserController(_userService);

            //Act
            var result = controller.CreateUser(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void UserController_UpdateUser_ReturnOk()
        {
            //Arrange
            var user = A.Fake<User>();
            var controller = new UserController(_userService);

            //Act
            var result = controller.UpdateUser(user);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void UserController_UpdateUser_ReturnBadRequest()
        {
            //Arrange
            var controller = new UserController(_userService);

            //Act
            var result = controller.UpdateUser(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }

        [Fact]
        public void UserController_DeleteUser_ReturnOk()
        {
            //Arrange
            var user = A.Fake<User>();
            var controller = new UserController(_userService);

            //Act
            var result = controller.DeleteUser(user);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void UserController_DeleteUser_ReturnBadRequest()
        {
            //Arrange
            var controller = new UserController(_userService);

            //Act
            var result = controller.DeleteUser(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void UserController_GetUserInfo_ReturnOk()
        {
            //Arrange
            var controller = new UserController(_userService);

            //Act
            var result = controller.GetUserInfo(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }
    }
}
