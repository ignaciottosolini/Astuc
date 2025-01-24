using Astuc.Domain.DTOs;
using EminenciasApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.Entities
{
    public class Carrito : BaseEntity
    {
        public string? Descripcion { get; set; }
        public string UserId { get; set; }
        public List<InsumoCarrito>? Insumos { get; set; }

    }

    
}
