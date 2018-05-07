namespace BusinessEntities
{
    using System;

    public partial class GrupoEntity
    {
        public int IdGrupo { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Nombre { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
