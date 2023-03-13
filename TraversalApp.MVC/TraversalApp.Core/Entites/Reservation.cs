using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class Reservation : BaseEntity
    {
        public int PersonCount { get; set; }
        public string? Status { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }


        //Relations
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
