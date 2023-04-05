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
        //public string? Status { get; set; }
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }


        //Relations
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public int RStatusId { get; set; }
        public RStatus RStatus { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
