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
        IEnumerable<RegistroEntity> GetByIdUsuario(string idUsuario, string fecha);
        IEnumerable<RegistroEntity> GetByIdItem(string idUsuario, string idItem, string fecha);
        IEnumerable<RegistroEntity> GetDashboard(string idUsuario);
        IEnumerable<RegistroEntity> formatRegistros(IEnumerable<RegistroEntity> registros);
        RegistroEntity formatRegistro(RegistroEntity registro);
        int CreateRegistroUrl(string latitud, string longitud, string tanqueConductor,
            string tanquePasajero, string botonPanico, string velocidad, string idUsuario, string idItem);
    }
}
