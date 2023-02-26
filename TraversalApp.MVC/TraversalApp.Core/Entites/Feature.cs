using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class Feature : BaseEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsBigArea { get; set; }

    }
}
