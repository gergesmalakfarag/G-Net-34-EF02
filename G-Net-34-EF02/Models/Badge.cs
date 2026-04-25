using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Net_34_EF02.Models
{
    internal class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; }
        public DateTime DateIssued { get; set; }

        public BadgeTier Tier { get; set; } 

        // Relationship with Attendee
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }
    public enum BadgeTier
    {
        Standard,
        VIP
    }
}
