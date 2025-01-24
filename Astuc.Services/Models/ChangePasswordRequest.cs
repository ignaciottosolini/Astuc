using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Application.Models
{
    public class ChangePasswordRequest
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }

        public string Email { get; set; }
    }
}
