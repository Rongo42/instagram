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
    public class PostControllerTest
    {
        private readonly ICustomService<Post> _postService;
        private readonly Type _ok, _notFound, _badRequest;

        public PostControllerTest()
        {
            _postService = A.Fake<ICustomService<Post>>();
            _ok = typeof(OkObjectResult);
            _notFound = typeof(NotFoundObjectResult);
            _badRequest = typeof(BadRequestResult);
        }

        [Fact]
        public void PostController_GetPostById_ReturnOk()
        {
            //Arrange
            var controller = new PostController(_postService);

            //Act
            var result = controller.GetPostById(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void PostController_GetAllPosts_ReturnOk()
        {
            //Arrange
            var controller = new PostController(_postService);

            //Act
            var result = controller.GetAllPosts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void PostController_CreatePost_ReturnOk()
        {
            //Arrange
            var post = A.Fake<Post>();
            var controller = new PostController(_postService);

            //Act
            var result = controller.CreatePost(post);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void PostController_CreatePost_ReturnBadRequest()
        {
            //Arrange
            var controller = new PostController(_postService);

            //Act
            var result = controller.CreatePost(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void PostController_UpdatePost_ReturnOk()
        {
            //Arrange
            var post = A.Fake<Post>();
            var controller = new PostController(_postService);

            //Act
            var result = controller.UpdatePost(post);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void PostController_UpdatePost_ReturnBadRequest()
        {
            //Arrange
            var controller = new PostController(_postService);

            //Act
            var result = controller.UpdatePost(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }

        [Fact]
        public void PostController_DeletePost_ReturnOk()
        {
            //Arrange
            var post = A.Fake<Post>();
            var controller = new PostController(_postService);

            //Act
            var result = controller.DeletePost(post);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void PostController_DeletePost_ReturnBadRequest()
        {
            //Arrange
            var controller = new PostController(_postService);

            //Act
            var result = controller.DeletePost(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }
    }
}
