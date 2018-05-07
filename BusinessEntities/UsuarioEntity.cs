namespace BusinessEntities
{
    using System;

    public partial class UsuarioEntity
    {
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
    }
}
