using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.DTOs.APIsDTO
{
    public class ApiMovieDto 
    {
        public int rank { get; set; }
        public string? title { get; set; }
        public string? rating { get; set; }
        public int year { get; set; }
        public string? image { get; set; }
        public string? trailer { get; set; }
    }
}
