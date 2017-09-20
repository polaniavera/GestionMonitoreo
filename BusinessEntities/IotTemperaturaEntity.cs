using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class IotTemperaturaEntity
    {
        public int Id { get; set; }
        public Nullable<int> IdIot { get; set; }
        public Nullable<int> Temperatura { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
    }
}
