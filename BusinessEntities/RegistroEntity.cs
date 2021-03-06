﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public partial class RegistroEntity
    {
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public Nullable<decimal> TanqueConductor { get; set; }
        public Nullable<decimal> TanquePasajero { get; set; }
        public Nullable<bool> BotonPanico { get; set; }
        public Nullable<int> Kilometraje { get; set; }
        public Nullable<int> Velocidad { get; set; }
        public string Fecha { get; set; }
        public System.TimeSpan Hora { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdItem { get; set; }
        public int IdRegistro { get; set; }

        public virtual Item Item { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
