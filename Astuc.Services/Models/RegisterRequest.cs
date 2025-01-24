using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Application.Models
{
    public class RegisterRequest
    {
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        //Acepta nulo porque por default es User
        public string? Role { get; set; } = "User";

        public bool Reprocainn { get; set; }
        //Membresia por default : Ninguna
        public int MembresiaId { get; set; } = 5;

    }
}
