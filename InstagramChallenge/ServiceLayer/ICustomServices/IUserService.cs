using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICustomServices
{
    //Inherits from the Custom Service interface in order to have the basic CRUD operations and declares a new required method
    public interface IUserService : ICustomService<User>
    {
        //Handles both the following and unfollowing of users and other users
        public void FollowUnfollow(User follower, User followed);
    }
}
