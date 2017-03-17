using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public partial class ItemEntity
    {
        public ItemEntity()
        {
            this.Registro = new HashSet<Registro>();
        }

        public int IdItem { get; set; }
        public string Placa { get; set; }
        public string Informacion { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdDocumento { get; set; }
        public Nullable<int> IdTipo { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Registro> Registro { get; set; }
    }
}
