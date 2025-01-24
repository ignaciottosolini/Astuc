using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.Models
{
    public class AddCartModel
    {
        public int Id { get; set; }
        public string UserId {get; set;}
        public int InsumoId { get; set;}    
        public int Cantidad { get; set;}

    }
}
