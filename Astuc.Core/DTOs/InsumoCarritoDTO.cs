﻿using Astuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astuc.Domain.DTOs
{
    public class InsumoCarritoDTO
    {
        public int Id { get; set; }
        public int CarritoId { get; set; }
        public int InsumoId { get; set; }
        public int Cantidad { get; set; }
        //public Insumo? Insumo { get; set; }


    }
}