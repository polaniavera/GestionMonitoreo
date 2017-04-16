//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registro
    {
        public int IdRegistro { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdItem { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public Nullable<decimal> TanqueConductor { get; set; }
        public Nullable<decimal> TanquePasajero { get; set; }
        public Nullable<int> Kilometraje { get; set; }
        public Nullable<int> Velocidad { get; set; }
        public Nullable<bool> BotonPanico { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
