using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace InstagramChallengeApiTests.Controllers
{
    public class FollowsControllerTest
    {
        private readonly IFollowsService _followsService;
        private readonly Type _ok, _notFound, _badRequest;

        public FollowsControllerTest()
        {
            _followsService = A.Fake<IFollowsService>();
            _ok = typeof(OkObjectResult);
            _notFound = typeof(NotFoundObjectResult);
            _badRequest = typeof(BadRequestResult);
        }

        [Fact]
        public void FollowsController_FollowUnfollow_ReturnOk()
        {

        }

        [Fact]
        public void FollowsController_FollowUnfollow_ReturnBadRequest()
        {

        }

        [Fact]
        public void FollowsController_GetFollowersByUserId_ReturnOk()
        {

        }

        [Fact]
        public void FollowsController_GetFollowersByUserId_ReturnBadRequest()
        {

        }
    }
}
