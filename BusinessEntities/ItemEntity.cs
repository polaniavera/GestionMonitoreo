namespace BusinessEntities
{
    using System;

    public partial class ItemEntity
    {
        public int IdItem { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdTipoItem { get; set; }
        public string Placa { get; set; }
        public string Informacion { get; set; }
        public Nullable<int> IdGrupo { get; set; }
    }
}
