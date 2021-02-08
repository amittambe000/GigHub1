using AutoMapper;
using GigHub1.App_Start;
using GigHub1.Models;
using GigHub1.Models.Dto;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub1.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {

        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context
                .UserNotifications
                .Where(x => x.UserId == userId && !x.IsRead)
                .Select(x => x.Notification)
                .Include(x => x.Gig.Artist)
                .ToList();

            var result = AutoMapperConfig.Mapper.Map<List<NotificationDto>>(notifications);
            return result;


        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications.Where(un => un.UserId == userId && !un.IsRead).ToList();
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();
            return Ok();



        }

    }
}
