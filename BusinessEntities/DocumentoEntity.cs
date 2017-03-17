using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public partial class DocumentoEntity
    {
        public DocumentoEntity()
        {
            this.Item = new HashSet<Item>();
        }

        public int IdDocumento { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> IdTipoDocumento { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
