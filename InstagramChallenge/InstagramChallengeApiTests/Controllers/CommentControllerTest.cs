using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using System.Runtime.CompilerServices;
using DomainLayer.Models;
using System.Linq.Expressions;
using InstagramWebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace InstagramChallengeApiTests.Controllers
{
    public class CommentControllerTest
    {
        private readonly ICustomService<Comment> _commentService;
        private readonly Type _ok, _notFound, _badRequest;

        public CommentControllerTest()
        {
            _commentService = A.Fake<ICustomService<Comment>>();
            _ok = typeof(OkObjectResult);
            _notFound = typeof(NotFoundObjectResult);
            _badRequest = typeof(BadRequestResult);
        }

        [Fact]
        public void CommentController_GetCommentById_ReturnOk()
        {
            //Arrange
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.GetCommentById(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void CommentController_GetAllComments_ReturnOk()
        {
            //Arrange
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.GetAllComments();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void CommentController_CreateComment_ReturnOk()
        {
            //Arrange
            var comment = A.Fake<Comment>();
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.CreateComment(comment);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void CommentController_CreateComment_ReturnBadRequest()
        {
            //Arrange
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.CreateComment(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void CommentController_UpdateComment_ReturnOk()
        {
            //Arrange
            var comment = A.Fake<Comment>();
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.UpdateComment(comment);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void CommentController_UpdateComment_ReturnBadRequest()
        {
            //Arrange
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.UpdateComment(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }

        [Fact]
        public void CommentController_DeleteComment_ReturnOk()
        {
            //Arrange
            var comment = A.Fake<Comment>();
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.DeleteComment(comment);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_ok);
        }

        [Fact]
        public void CommentController_DeleteComment_ReturnBadRequest()
        {
            //Arrange
            var controller = new CommentController(_commentService);

            //Act
            var result = controller.DeleteComment(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(_badRequest);
        }
    }
}
