using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.DTOs
{
    public class UserEditDto : AppUserDto
    {
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile Images { get; set; }
    }
}
