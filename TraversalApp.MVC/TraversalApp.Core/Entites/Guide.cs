using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class Guide : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? TwitterURL { get; set; }
        public string? InstagramURL { get; set; }
        public bool Status { get; set; }

        public ICollection<Destination> Destinations { get; set; }
    }
}
