using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class EventDiscussion
    {
        public Guid DiscussionId { get; set; }
        public Guid? EventId { get; set; }
        public Guid? UserId { get; set; }
        public string? Message { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
