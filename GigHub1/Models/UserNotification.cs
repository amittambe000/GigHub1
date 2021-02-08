using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub1.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }


        public UserNotification()
        {

        }
        public UserNotification(ApplicationUser user, Notification notification)
        {

            User = user ?? throw new ArgumentException("User");
            Notification = notification ?? throw new ArgumentException("Notification");
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}