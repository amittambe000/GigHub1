using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub1.Models
{
    public class Notification
    {
        //private NotificationType gigCanceled;

        private Notification(NotificationType type, Gig gig)
        {
            Gig = gig ?? throw new ArgumentException("Gig cannot be null");
            this.Type = type;
            DateTime = DateTime.Now;
        }

        protected Notification()
        {

        }

        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }


        public static Notification GigCreated(Gig gig) => new Notification(NotificationType.GigCreated, gig);
        public static Notification GigCanceled(Gig gig) => new Notification(NotificationType.GigCanceled, gig);
        public static Notification GigUpdated(Gig gigNew, DateTime originalDateTime, string venue)
        {
            var notification = new Notification(NotificationType.GigUpdated, gigNew);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = venue;
            return notification;


        }

    }
}