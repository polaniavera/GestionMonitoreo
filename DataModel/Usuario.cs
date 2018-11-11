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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Item = new HashSet<Item>();
            this.Registro = new HashSet<Registro>();
            this.Grupo = new HashSet<Grupo>();
            this.Conductor = new HashSet<Conductor>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<decimal> Telefono { get; set; }
        public string Empresa { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Username { get; set; }
    
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Registro> Registro { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<Conductor> Conductor { get; set; }
    }
}
