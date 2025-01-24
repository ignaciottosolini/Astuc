using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.DTOs
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaYHora { get; set; }
        public string Lugar { get; set; }   
        public string ImagenPrincipal { get; set; }
        public decimal Precio { get; set; }
        public bool EsGratis { get; set; }

       
    }
}
