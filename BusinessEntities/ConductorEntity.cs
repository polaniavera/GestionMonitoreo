namespace BusinessEntities
{
    using System;

    public partial class ConductorEntity
    {
        public int IdConductor { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<decimal> Telefono { get; set; }
        public string Direccion { get; set; }
        public string Licencia { get; set; }
        public string Clase { get; set; }
        public Nullable<System.DateTime> FechaExpiracion { get; set; }
    }
}
