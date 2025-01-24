using EminenciasApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.Entities
{
    public class Publicacion : BaseEntity
    {
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public string imagenPrincipal { get; set; }
    }
}
