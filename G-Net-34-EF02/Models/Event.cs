using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Net_34_EF02.Models
{
    internal class Event 
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxAttendees { get; set; }

        // Relationship with Organizer
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        // Self-Referencing (Parent/Child)
        public int? ParentEventId { get; set; }
        public Event ParentEvent { get; set; }
        public ICollection<Event> Sessions { get; set; }

        // Many-to-Many via Registration
        public ICollection<Registration> Registrations { get; set; }
    }
}
