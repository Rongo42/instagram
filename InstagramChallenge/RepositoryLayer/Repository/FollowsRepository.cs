using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class FollowsRepository : Repository<Follows>, IFollowsRepository
    {
        public FollowsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        //This method returns the follow action between followedUser and followerUser in order to manage the follow/unfollow logic
        public Follows GetFollowsByUsers(User followedUser, User followerUser)
        {
            //The owner or followedUser represents the user that receives a new follower
            //The follower or followerUser represents the user that is being added to the owner's followers list
            return entities.SingleOrDefault(c => c.OwnerId == followedUser.Id && c.FollowerId == followerUser.Id);
        }

        //This method return a list of follower ids the user or owner has
        public IEnumerable<Follows> GetFollowersByUserId(int Id)
        {
            return entities.FromSql($"SELECT [FollowerId] FROM [Instagram].[dbo].[Followss] WHERE [OwnerId] = {Id};");
        }
    }
}
