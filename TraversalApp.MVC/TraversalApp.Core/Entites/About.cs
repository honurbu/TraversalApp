using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class About : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Title1 { get; set; }

        public string Description1 { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }
    }
}
