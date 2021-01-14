using GigHub1.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using GigHub1.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GigHub1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Genre)
                .Include(g => g.Artist)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);



            var viewModel = new GigsViewModel
            {
                UpcommingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"

            };

            return View("Gigs", viewModel);
        }

        [Authorize]
        public ActionResult FollowingArtist()
        {
            var userId = User.Identity.GetUserId();

            var artists = _context.Followings.Where(f => f.FollowerId == userId).Select(f => f.Followee).ToList();

            // var ApplicationUser = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            // var artist = ApplicationUser.Followees;
            return View("FollowingArtist", artists);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}