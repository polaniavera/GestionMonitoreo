using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices
{
    public class ConductorServices : IConductorServices
    {
        private readonly UnitOfWork _unitOfWork;
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ConductorServices()
        {
            _unitOfWork = new UnitOfWork();
            this.Context = new MonitoreoDbEntities();
        }

        /// <summary>
        /// Creates a conductor
        /// </summary>
        /// <param name="conductorEntity"></param>
        /// <returns></returns>
        public int CreateConductor(ConductorEntity conductorEntity)
        {
            //registroEntity = formatTimeCreate(registroEntity);

            using (var scope = new TransactionScope())
            {
                var conductor = new Conductor
                {
                    Nombre = conductorEntity.Nombre,
                    Apellido = conductorEntity.Apellido,
                    Telefono = conductorEntity.Telefono,
                    Direccion = conductorEntity.Direccion,
                    Licencia = conductorEntity.Licencia,
                    Clase = conductorEntity.Clase,
                    FechaExpiracion = conductorEntity.FechaExpiracion,
                    IdUsuario = conductorEntity.IdUsuario
                    //Fecha = DateTime.Parse(registroEntity.Fecha),
                };
                _unitOfWork.ConductorRepository.Insert(conductor);
                _unitOfWork.Save();
                scope.Complete();
                return conductor.IdConductor;
            }
        }
    }
}
