using Astuc.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Application.Models
{
    public class UserWithRoles
    {
        public ApplicationUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
