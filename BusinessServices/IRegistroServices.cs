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
        int CreateRegistroPrueba(Test testEntity);
        bool UpdateRegistro(int registroId, RegistroEntity registroEntity);
        bool DeleteRegistro(int registroId);
        IEnumerable<RegistroEntity> GetByIdUsuario(string idUsuario, string fecha);
        IEnumerable<RegistroEntity> GetByIdItem(string idUsuario, string idItem, string fecha);
        int CreateRegistroUrl(string latitud, string longitud, string tanqueConductor,
            string tanquePasajero, string botonPanico, string velocidad, string idUsuario, string idItem);
    }
}
