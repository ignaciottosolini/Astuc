using Astuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.DTOs
{
    public class CarritoDTO
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string UserId { get; set; }
        public List<InsumoCarrito>? Insumos { get; set; }

    }
}