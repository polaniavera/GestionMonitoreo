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
            //this.Documento = new HashSet<Documento>();
            //this.Registro = new HashSet<Registro>();
        }

        public int IdItem { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdTipoItem { get; set; }
        public string Placa { get; set; }
        public string Informacion { get; set; }

        //public virtual ICollection<Documento> Documento { get; set; }
        //public virtual Usuario Usuario { get; set; }
        //public virtual ICollection<Registro> Registro { get; set; }
    }
}
