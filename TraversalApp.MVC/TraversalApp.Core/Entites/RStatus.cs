using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class RStatus : BaseEntity
    {
        public string Defination { get; set; }

        //Relations
        public ICollection<Reservation> Reservations { get; set; }
    }
}
