using Astuc.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.DTOs
{
    public class ApplicationUser : IdentityUser
    {
        public bool Reprocainn { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone {get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public bool Active { get; set; } = true;

        public int MembresiaId { get; set; }
        public Membresia? Membresia { get; set; }    

    }
}
