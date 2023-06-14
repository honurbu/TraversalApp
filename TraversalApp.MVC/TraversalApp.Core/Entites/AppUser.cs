using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Gender { get; set; }
        //public string ConfirmPassword { get; set; }

        //Relations
        public ICollection<Reservation> Reservations { get; set; }
        // public List<Comment> Comments { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
