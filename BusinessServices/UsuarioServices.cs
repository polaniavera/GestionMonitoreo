using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly UnitOfWork _unitOfWork;
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UsuarioServices(UnitOfWork unitOfWork,
            MonitoreoDbEntities context)
        {
            _unitOfWork = unitOfWork;
            this.Context = context;
        }

        /// <summary>
        /// Fetches usuario by idUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UsuarioEntity</returns>
        public UsuarioEntity GetUserById(string userId)
        {
            int _idUsuario = Int32.Parse(userId);
            var usuario = _unitOfWork.UsuarioRepository.Get(c => c.IdUsuario == _idUsuario);
            if (usuario != null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Usuario, UsuarioEntity>();
                });
                var usuarioModel = Mapper.Map<Usuario, UsuarioEntity>(usuario);

                return usuarioModel;
            }
            return null;
        }
       
    }
}
