using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class VehiculosEntity
    {
        public Nullable<int> IdItem { get; set; }
        public Nullable<int> IdTipoItem { get; set; }
        public int IdRegistro { get; set; }
        public string Placa { get; set; }
        public string Informacion { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public Nullable<decimal> TanqueConductor { get; set; }
        public Nullable<decimal> TanquePasajero { get; set; }
        public Nullable<bool> BotonPanico { get; set; }
        public Nullable<int> Kilometraje { get; set; }
        public Nullable<int> Velocidad { get; set; }
        public string Fecha { get; set; }
        public System.TimeSpan Hora { get; set; }
    }
}
