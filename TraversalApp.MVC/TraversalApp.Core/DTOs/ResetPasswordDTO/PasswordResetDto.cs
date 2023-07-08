using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.DTOs.ResetPasswordDTO
{
    public class PasswordResetDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
