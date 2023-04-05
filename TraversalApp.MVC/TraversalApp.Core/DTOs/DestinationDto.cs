using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.DTOs
{
    public class DestinationDto : BaseDto
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }

    }
}
