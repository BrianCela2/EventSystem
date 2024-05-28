using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Event
    {
        public Event()
        {
            EventDiscussions = new HashSet<EventDiscussion>();
            EventRegistrations = new HashSet<EventRegistration>();
        }

        public Guid EventId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Visibility { get; set; }
        public Guid? OrganizerId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User? Organizer { get; set; }
        public virtual ICollection<EventDiscussion> EventDiscussions { get; set; }
        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}
