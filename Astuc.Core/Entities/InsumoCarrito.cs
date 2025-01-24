using EminenciasApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.Entities
{
    public class InsumoCarrito : BaseEntity
    {
        public int CarritoId { get; set; }
        public int InsumoId { get; set; }
        public Insumo? Insumo { get; set; }
        public int Cantidad { get; set; }   
    }
}
