using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.GenericRepository
{
    public class RegistroCustomRepository
    {
        #region Private member variables...
        internal MonitoreoDbEntities Context;
        internal DbSet<Registro> DbSet;
        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public RegistroCustomRepository(MonitoreoDbEntities context)
        {
            this.Context = context;
            this.DbSet = context.Set<Registro>();
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// generic method to get many records from registro with the idUsuario and fecha.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<Registro> GetByIdUsuario(string idUsuario, string fecha)
        {
            int _idUsuario = Int32.Parse(idUsuario);
            DateTime _fecha = Convert.ToDateTime(fecha);

            var registroByUser = Context.Registro.Where(c => c.IdUsuario == _idUsuario && c.Fecha == _fecha).ToList();
            registroByUser.OrderBy(x => x.Hora).ToList();
            return registroByUser;
        }

        /// <summary>
        /// generic method to get many records from registro with the idUsuario, idItem and fecha.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<Registro> GetByIdItem(string idUsuario, string idItem, string fecha)
        {
            int _idUsuario = Int32.Parse(idUsuario);
            int _idItem = Int32.Parse(idItem);
            DateTime _fecha = Convert.ToDateTime(fecha);

            var registroByItem = Context.Registro.Where(c => c.IdUsuario == _idUsuario && c.IdItem == _idItem && c.Fecha == _fecha).ToList();
            registroByItem.OrderBy(x => x.Hora).ToList();
            return registroByItem;
        }

        #endregion
    }
}
