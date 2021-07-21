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
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var userId = User.Identity.GetUserId();

            // var follow = _dbContext.Followings
            //     .SingleOrDefault(a => a.FollowerId == userId && a.FolloweeId == id);
            var follow = _dbContext.Followings
                .SingleOrDefault(a => a.FollowerId == userId && a.FolloweeId==id);
            if (follow == null)
                return NotFound();

            _dbContext.Followings.Remove(follow);
            _dbContext.SaveChanges();

            return Ok(id);
        }

    }
}
