using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User
    {
        public User()
        {
            EventDiscussions = new HashSet<EventDiscussion>();
            EventRegistrations = new HashSet<EventRegistration>();
            Events = new HashSet<Event>();
            NotificationReceivers = new HashSet<Notification>();
            NotificationSenders = new HashSet<Notification>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<EventDiscussion> EventDiscussions { get; set; }
        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Notification> NotificationReceivers { get; set; }
        public virtual ICollection<Notification> NotificationSenders { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
