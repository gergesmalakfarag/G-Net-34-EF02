using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Net_34_EF02.Models
{
    internal class Profile
    {
        public int Id { get; set; }
        public string Biography { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoPath { get; set; }

        // Foreign Key (Convention: OrganizerId)
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }
    }
}
