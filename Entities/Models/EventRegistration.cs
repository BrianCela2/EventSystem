using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class EventRegistration
    {
        public Guid RegistrationId { get; set; }
        public Guid? EventId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
