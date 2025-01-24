using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.DTOs
{
    public class UserDTO
    {
        public string? Email {  get; set; }
        public string Id { get; set; }
        public bool Reprocainn { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public bool Active { get; set; }
        public string Role { get; set; }
        public int MembresiaId { get; set; }
    }
}
