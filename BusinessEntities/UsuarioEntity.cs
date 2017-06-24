using DataModel;
using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public partial class UsuarioEntity
    {
        public UsuarioEntity()
        {
            this.Item = new HashSet<Item>();
            this.Registro = new HashSet<Registro>();
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
    }
}
