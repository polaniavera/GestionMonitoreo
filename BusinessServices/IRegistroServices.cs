using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IRegistroServices
    {
        RegistroEntity GetRegistroById(int registroId);
        IEnumerable<RegistroEntity> GetAllRegistros();
        int CreateRegistro(RegistroEntity registroEntity);
        bool UpdateRegistro(int registroId, RegistroEntity registroEntity);
        bool DeleteRegistro(int registroId);
        IEnumerable<RegistroEntity> GetByIdUsuarioList(int idUsuario, DateTime fecha);
        int CreateRegistroUrl(decimal latitud, decimal longitud, decimal tanqueConductor,
            decimal tanquePasajero, bool botonPanico, decimal kilometraje,
            decimal velocidad, DateTime fecha, TimeSpan hora, int idUsuario, int idItem);
         int CreateRegistroUrl(string latitud, string longitud, string tanqueConductor,
            string tanquePasajero, string botonPanico, string kilometraje,
            string velocidad, string fecha, string hora, string idUsuario, string idItem);
    }
}
