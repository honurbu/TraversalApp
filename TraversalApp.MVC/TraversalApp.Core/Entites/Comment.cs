using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Entites
{
    public class Comment : BaseEntity
    {
        public string CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
        public bool CommentStatus { get; set; }


        //Navigations
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }


    }
}
