using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class EstacionesEntity
    {
        public int IdEstacion { get; set; }
        public string Campo { get; set; }
        public string Operadora { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
    }
}
