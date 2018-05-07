using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices
{
    public class GrupoServices : IGrupoServices
    {
        private readonly UnitOfWork _unitOfWork;
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public GrupoServices()
        {
            _unitOfWork = new UnitOfWork();
            this.Context = new MonitoreoDbEntities();
        }

        /// <summary>
        /// Fetches grupos by idUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>IEnumerable<ItemEntity></returns>
        public IEnumerable<GrupoEntity> GetGruposByUser(string userId)
        {
            int _idUsuario = Int32.Parse(userId);
            var grupos = _unitOfWork.GrupoRepository.GetMany(c => c.IdUsuario == _idUsuario).ToList();
            if (grupos.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Grupo, GrupoEntity>();
                });
                var gruposModel = Mapper.Map<List<Grupo>, List<GrupoEntity>>(grupos);

                return gruposModel;
            }
            return null;
        }
        
    }
}