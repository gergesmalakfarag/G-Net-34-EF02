using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Net_34_EF02.Models
{
    internal class Organizer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public bool IsVerified { get; set; }


        public Profile Profile { get; set; }
        public ICollection<Event> Events { get; set; }
    

    }
}
