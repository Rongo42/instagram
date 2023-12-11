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
    public class LikeControllerTest
    {
        private readonly ILikeService _likeService;
        private readonly Type _ok, _badRequest;

        public LikeControllerTest()
        {
            _likeService = A.Fake<ILikeService>();
            _ok = typeof(OkObjectResult);
            _badRequest = typeof(BadRequestObjectResult);
        }

        [Fact]
        public void LikeController_GetLikeById_ReturnOk()
        {
            //Arrange
            var controller = new LikeController(_likeService);

            //Act
            var result = controller.GetLikeById(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void LikeController_GetAllLikes_ReturnOk()
        {
            //Arrange
            var controller = new LikeController(_likeService);

            //Act
            var result = controller.GetAllLikes();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void LikeController_LikeUnlike_ReturnOk()
        {
            //Arrange
            var like = A.Fake<Like>();
            var controller = new LikeController(_likeService);

            //Act
            var result = controller.LikeUnlike(like);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void LikeController_LikeUnlike_ReturnBadRequest()
        {
            //Arrange
            var controller = new LikeController(_likeService);

            //Act
            var result = controller.LikeUnlike(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
