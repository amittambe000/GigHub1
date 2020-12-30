using GigHub1.Dtos;
using GigHub1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Http;

namespace GigHub1.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult Follow(FollowingDto dto)
        {

            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId

            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
