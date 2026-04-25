using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace G_Net_34_EF02.Models
{
    internal class Attendee 
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }

        // Owned Type 
        public Addres Address { get; set; }

        public Badge Badge { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}