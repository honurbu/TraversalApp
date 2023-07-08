using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.DTOs
{
    public class RoleAssignDto : BaseDto
    {
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }
    }
}
