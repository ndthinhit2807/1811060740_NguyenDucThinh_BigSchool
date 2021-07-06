using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using _1811060740_NguyenDucThinh_BigSchool.DTos;
using _1811060740_NguyenDucThinh_BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace _1811060740_NguyenDucThinh_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDTO)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDTO.FolloweeId))
            {
                return BadRequest("The Attendance already exits");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDTO.FolloweeId
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string followeeId, string followerId)
        {
            var unfollow = (from a in _dbContext.Followings
                where a.FolloweeId == followeeId && a.FollowerId == followerId
                select a).SingleOrDefault();


            _dbContext.Followings.Remove(unfollow);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}