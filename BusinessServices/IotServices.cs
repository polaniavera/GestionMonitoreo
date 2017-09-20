using AutoMapper;
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
    public class IotServices : IIotServices
    {
        private readonly UnitOfWork _unitOfWork;
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public IotServices()
        {
            _unitOfWork = new UnitOfWork();
            this.Context = new MonitoreoDbEntities();
        }

        /// <summary>
        /// Fetches all the registros iot.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IotTemperaturaEntity> GetAllRegistros()
        {
            var registros = _unitOfWork.IotTemperaturaRepository.GetAll().ToList();
            if (registros.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<IotTemperatura, IotTemperaturaEntity>();
                });
                var registrosModel = Mapper.Map<List<IotTemperatura>, List<IotTemperaturaEntity>>(registros);

                return registrosModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches registro iot details by id
        /// </summary>
        /// <param name="registroId"></param>
        /// <returns></returns>
        public IotTemperaturaEntity GetRegistroById(int registroId)
        {
            var registro = _unitOfWork.IotTemperaturaRepository.GetByID(registroId);
            if (registro != null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<IotTemperatura, IotTemperaturaEntity>();
                });
                var registroModel = Mapper.Map<IotTemperatura, IotTemperaturaEntity>(registro);

                return registroModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the registros iot by fecha.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IotTemperaturaEntity> GetByFecha(string fecha)
        {
            DateTime _fecha = Convert.ToDateTime(fecha);
            var registros = _unitOfWork.IotTemperaturaRepository.GetMany(p => p.Fecha == _fecha).ToList();
            if (registros.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<IotTemperatura, IotTemperaturaEntity>();
                });
                var registrosModel = Mapper.Map<List<IotTemperatura>, List<IotTemperaturaEntity>>(registros);

                return registrosModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a Iot register
        /// </summary>
        /// <param name="data">int</param>
        /// <returns>int</returns>
        public int CreateIot(string temperatura)
        {
            DateTime fechaActual = DateTime.Now;
            var horaActual = fechaActual.TimeOfDay;

            using (var scope = new TransactionScope())
            {
                var iotTempertura = new IotTemperatura
                {
                    IdIot = 1,
                    Temperatura = Int32.Parse(temperatura),
                    Fecha = fechaActual,
                    Hora = horaActual
                };
                _unitOfWork.IotTemperaturaRepository.Insert(iotTempertura);
                _unitOfWork.Save();
                scope.Complete();
                return iotTempertura.Id;
            }
        }
    }
}
