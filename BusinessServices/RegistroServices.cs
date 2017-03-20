using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BusinessServices
{
    /// <summary>
    /// Offers services for product specific CRUD operations
    /// </summary>
    public class RegistroServices : IRegistroServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public RegistroServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches registro details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public BusinessEntities.RegistroEntity GetRegistroById(int registroId)
        {
            var registro = _unitOfWork.RegistroRepository.GetByID(registroId);
            if (registro != null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Registro, RegistroEntity>();
                });
                var registroModel = Mapper.Map<Registro, RegistroEntity>(registro);

                return registroModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the registros.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.RegistroEntity> GetAllRegistros()
        {
            var registros = _unitOfWork.RegistroRepository.GetAll().ToList();
            if (registros.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Registro, RegistroEntity>();
                });
                var registrosModel = Mapper.Map<List<Registro>, List<RegistroEntity>>(registros);

                return registrosModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a registro
        /// </summary>
        /// <param name="registroEntity"></param>
        /// <returns></returns>
        public int CreateRegistro(BusinessEntities.RegistroEntity registroEntity)
        {
            using (var scope = new TransactionScope())
            {
                var registro = new Registro
                {
                    BotonPanico = registroEntity.BotonPanico,
                    Fecha = registroEntity.Fecha,
                    Hora = registroEntity.Hora,
                    IdItem = registroEntity.IdItem,
                    IdRegistro = registroEntity.IdRegistro,
                    IdUsuario = registroEntity.IdUsuario,
                    Item = registroEntity.Item,
                    Kilometraje = registroEntity.Kilometraje,
                    Latitud = registroEntity.Latitud,
                    Longitud = registroEntity.Longitud,
                    TanqueConductor = registroEntity.TanqueConductor,
                    TanquePasajero = registroEntity.TanquePasajero,
                    Usuario = registroEntity.Usuario,
                    Velocidad = registroEntity.Velocidad
                };
                _unitOfWork.RegistroRepository.Insert(registro);
                _unitOfWork.Save();
                scope.Complete();
                return registro.IdRegistro;
            }
        }

        /// <summary>
        /// Updates a registro
        /// </summary>
        /// <param name="registroId"></param>
        /// <param name="registroEntity"></param>
        /// <returns></returns>
        public bool UpdateRegistro(int registroId, BusinessEntities.RegistroEntity registroEntity)
        {
            var success = false;
            if (registroEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var registro = _unitOfWork.RegistroRepository.GetByID(registroId);
                    if (registro != null)
                    {
                        registro.BotonPanico = registroEntity.BotonPanico;
                        registro.Fecha = registroEntity.Fecha;
                        registro.Hora = registroEntity.Hora;
                        registro.IdItem = registroEntity.IdItem;
                        registro.IdRegistro = registroEntity.IdRegistro;
                        registro.IdUsuario = registroEntity.IdUsuario;
                        registro.Item = registroEntity.Item;
                        registro.Kilometraje = registroEntity.Kilometraje;
                        registro.Latitud = registroEntity.Latitud;
                        registro.Longitud = registroEntity.Longitud;
                        registro.TanqueConductor = registroEntity.TanqueConductor;
                        registro.TanquePasajero = registroEntity.TanquePasajero;
                        registro.Usuario = registroEntity.Usuario;
                        registro.Velocidad = registroEntity.Velocidad;

                        _unitOfWork.RegistroRepository.Update(registro);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular registro
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteRegistro(int registroId)
        {
            var success = false;
            if (registroId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var registro = _unitOfWork.RegistroRepository.GetByID(registroId);
                    if (registro != null)
                    {

                        _unitOfWork.RegistroRepository.Delete(registro);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        //Metodo para insertar un registro con parametros pasados por URL
        public int CreateRegistroUrl(decimal latitud, decimal longitud, decimal tanqueConductor,
            decimal tanquePasajero, bool botonPanico, decimal kilometraje,
            decimal velocidad, DateTime fecha, TimeSpan hora, int idUsuario, int idItem)
        {
            using (var scope = new TransactionScope())
            {
                var registro = new Registro
                {
                    BotonPanico = botonPanico,
                    Fecha = fecha,
                    Hora = hora,
                    IdItem = idItem,
                    IdUsuario = idUsuario,
                    Item = null,
                    Kilometraje = kilometraje,
                    Latitud = latitud,
                    Longitud = longitud,
                    TanqueConductor = tanqueConductor,
                    TanquePasajero = tanquePasajero,
                    Usuario = null,
                    Velocidad = velocidad
                };
                _unitOfWork.RegistroRepository.Insert(registro);
                _unitOfWork.Save();
                scope.Complete();
                return registro.IdRegistro;
            }
        }
        
        //TEST*********************************************************************************************************
        public int CreateRegistroUrl(string latitud, string longitud, string tanqueConductor,
            string tanquePasajero, string botonPanico, string kilometraje,
            string velocidad, string fecha, string hora, string idUsuario, string idItem)
        {
            return 1000;
        }


        /// <summary>
        /// Fetches all the registros by IdUsuario.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegistroEntity> GetByIdUsuarioList(int idUsuario, DateTime fecha)
        {
            var registros = _unitOfWork.RegistroCustomRepository.GetByIdUsuario().ToList();
            if (registros.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Registro, RegistroEntity>();
                });
                var registrosModel = Mapper.Map<List<Registro>, List<RegistroEntity>>(registros);

                return registrosModel;
            }
            return null;
        }
        

    }
}
