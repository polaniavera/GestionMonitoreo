using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices
{
    public class EstacionesServices : IEstacionesServices
    {
        private readonly UnitOfWork _unitOfWork;
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public EstacionesServices()
        {
            _unitOfWork = new UnitOfWork();
            this.Context = new MonitoreoDbEntities();
        }

        /// <summary>
        /// Fetches all the estaciones.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EstacionesEntity> GetAllEstaciones()
        {
            var estaciones = _unitOfWork.EstacionesRepository.GetAll().ToList();
            if (estaciones.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Estaciones, EstacionesEntity>();
                });
                var estacionesModel = Mapper.Map<List<Estaciones>, List<EstacionesEntity>>(estaciones);

                return estacionesModel;
            }
            return null;
        }
    }
}
