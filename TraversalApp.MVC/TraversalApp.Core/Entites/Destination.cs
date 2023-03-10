using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class Destination : BaseEntity
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string TopDetails { get; set; }
        public string SubDetails { get; set; }
        public string CoverImage { get; set; }
        public string ContentImage { get; set; }
        public string? Maxim { get; set; }
        public string? MaximAuthor { get; set; }
        public bool MaximStatus { get; set; }


        //Navigations
        public ICollection<Comment> Comments { get; set;}
    }
}
