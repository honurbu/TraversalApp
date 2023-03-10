using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.DTOs
{
    public class SignInDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
