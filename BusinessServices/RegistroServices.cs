using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
        internal MonitoreoDbEntities Context;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public RegistroServices()
        {
            _unitOfWork = new UnitOfWork();
            this.Context = new MonitoreoDbEntities();
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
            registroEntity = formatTimeCreate(registroEntity);

            using (var scope = new TransactionScope())
            {
                var registro = new Registro
                {
                    BotonPanico = registroEntity.BotonPanico,
                    Fecha = DateTime.Parse(registroEntity.Fecha),
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
        /// Creates a registro
        /// </summary>
        /// <param name="registroEntity"></param>
        /// <returns></returns>
        public int CreateMultiRegistro(List<RegistroEntity> listRegistroEntity)
        {
            int conteo = 0;
            for (int i = 0; i < listRegistroEntity.Count; i++)
            {
                //listRegistroEntity[i] = formatTimeCreate(listRegistroEntity[i]);

                using (var scope = new TransactionScope())
                {
                    var registro = new Registro
                    {
                        BotonPanico = listRegistroEntity[i].BotonPanico,
                        Fecha = DateTime.Parse(listRegistroEntity[i].Fecha),
                        Hora = listRegistroEntity[i].Hora,
                        IdItem = listRegistroEntity[i].IdItem,
                        IdRegistro = listRegistroEntity[i].IdRegistro,
                        IdUsuario = listRegistroEntity[i].IdUsuario,
                        Item = listRegistroEntity[i].Item,
                        Kilometraje = listRegistroEntity[i].Kilometraje,
                        Latitud = listRegistroEntity[i].Latitud,
                        Longitud = listRegistroEntity[i].Longitud,
                        TanqueConductor = listRegistroEntity[i].TanqueConductor,
                        TanquePasajero = listRegistroEntity[i].TanquePasajero,
                        Usuario = listRegistroEntity[i].Usuario,
                        Velocidad = listRegistroEntity[i].Velocidad
                    };
                    _unitOfWork.RegistroRepository.Insert(registro);
                    _unitOfWork.Save();
                    conteo++;
                    scope.Complete();
                }
            }
            return conteo;
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
                        registro.Fecha = DateTime.Parse(registroEntity.Fecha);
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
        
        public int CreateRegistroUrl(string latitud, string longitud, string tanqueConductor,
            string tanquePasajero, string botonPanico, string velocidad, string idUsuario, string idItem)
        {
            if (botonPanico.Equals("1"))
                botonPanico = "true";
            else
                botonPanico = "false";

            //DateTime _fecha = Convert.ToDateTime(fecha);
            //_fecha = _fecha.Date;
            //TimeSpan _hora = TimeSpan.Parse(hora);
            DateTime fechaActual = DateTime.Now;
            var horaActual = fechaActual.TimeOfDay;

            using (var scope = new TransactionScope())
            {
                var registro = new Registro
                {
                    IdUsuario = Int32.Parse(idUsuario),
                    IdItem = Int32.Parse(idItem),
                    Fecha = fechaActual,
                    Hora = horaActual,
                    Latitud = Convert.ToDecimal(latitud, CultureInfo.InvariantCulture),
                    Longitud = Convert.ToDecimal(longitud, CultureInfo.InvariantCulture),
                    TanqueConductor = Convert.ToDecimal(tanqueConductor, CultureInfo.InvariantCulture),
                    TanquePasajero = Convert.ToDecimal(tanquePasajero, CultureInfo.InvariantCulture),
                    BotonPanico = Convert.ToBoolean(botonPanico),
                    Velocidad = Int32.Parse(velocidad),
                    Kilometraje = 100,
                    Usuario = null,
                    Item = null
                };
                _unitOfWork.RegistroRepository.Insert(registro);
                _unitOfWork.Save();
                scope.Complete();
                return registro.IdRegistro;
            }
        }


        /// <summary>
        /// Fetches all the registros by IdUsuario.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegistroEntity> GetByIdUsuario(string idUsuario, string fecha)
        {
            var registros = _unitOfWork.RegistroCustomRepository.GetByIdUsuario(idUsuario, fecha).ToList();
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
        /// Fetches all the registros by IdItem.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegistroEntity> GetByIdItem(string idUsuario, string idItem, string fecha)
        {
            var registros = _unitOfWork.RegistroCustomRepository.GetByIdItem(idUsuario, idItem, fecha).ToList();
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
        /// Fetches all the registros by IdItem and date range.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegistroEntity> GetByIdItemRange(string idUsuario, string idItem, string fechaInicial, string fechaFinal)
        {
            int _idUsuario = Int32.Parse(idUsuario);
            int _idItem = Int32.Parse(idItem);
            DateTime _fechaInicial = Convert.ToDateTime(fechaInicial);
            DateTime _fechaFinal = Convert.ToDateTime(fechaFinal);

            var registros = _unitOfWork.RegistroRepository.GetMany(c => c.IdUsuario == _idUsuario && c.IdItem == _idItem && c.Fecha >= _fechaInicial && c.Fecha <= _fechaFinal).ToList();

            foreach (Registro registro in registros)
            {
                registro.Fecha = registro.Fecha.Value.AddHours(registro.Hora.Value.Hours).AddMinutes(registro.Hora.Value.Minutes).AddSeconds(registro.Hora.Value.Seconds);
            }

            registros = registros.OrderBy(x => x.Fecha).ToList();

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
        /// Obtiene el ultimo registro de cada item de un usuario, vista dashboard ingreso
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns>IEnumerable<RegistroEntity></returns>
        public IEnumerable<RegistroEntity> GetDashboard(string idUsuario)
        {
            List<Registro> registros =
                _unitOfWork.RegistroRepository.ExecWithStoreProcedure("getMaximaLectura @idUsuario",
                new SqlParameter("idUsuario", SqlDbType.Int) { Value = idUsuario }).ToList();

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
        /// Obtiene el registro de cada item de un usuario filtrado por fecha, vista dashboard principal con filtro fecha
        /// </summary>
        /// <param name="idUsuario">string</param>
        /// <param name="fecha">string</param>
        /// <returns>IEnumerable<RegistroEntity></returns>
        public IEnumerable<RegistroEntity> GetDashboardByDate(string idUsuario, string fecha)
        {
            List<Registro> registros =
                _unitOfWork.RegistroRepository.ExecWithStoreProcedure("getMaxLecturaByFecha @idUsuario, @fecha",
                new SqlParameter("idUsuario", SqlDbType.Int) { Value = idUsuario },
                new SqlParameter("fecha", SqlDbType.VarChar) { Value = fecha }).ToList();

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
        /// Formatea el campo Registro.Fecha para eliminar hora por defecto del DateTime
        /// </summary>
        /// <param name="registros">IEnumerable<RegistroEntity></param>
        /// <returns>IEnumerable<RegistroEntity></returns>
        public IEnumerable<RegistroEntity> formatRegistros(IEnumerable<RegistroEntity> registros)
        {
            foreach (RegistroEntity registro in registros)
            {
                if(registro.Fecha!=null && registro.Fecha!=string.Empty)
                    registro.Fecha = registro.Fecha.Substring(0, registro.Fecha.IndexOf(" "));
            }

            return registros;
        }

        /// <summary>
        /// Formatea el campo Registro.Fecha para eliminar hora por defecto del DateTime
        /// </summary>
        /// <param name="registro">RegistroEntity</param>
        /// <returns>RegistroEntity</returns>
        public RegistroEntity formatRegistro(RegistroEntity registro)
        {
            if (registro.Fecha != null && registro.Fecha != string.Empty)
                registro.Fecha = registro.Fecha.Substring(0, registro.Fecha.IndexOf(" "));

            return registro;
        }

        /// <summary>
        /// Formatea el campo Registro.Fecha para cambiar hora GMT00 GMT-5 del DateTime
        /// </summary>
        /// <param name="registro">RegistroEntity</param>
        /// <returns>RegistroEntity</returns>
        public RegistroEntity formatTimeCreate(RegistroEntity registro)
        {
            string fechaStr = string.Empty;
            DateTime fechaDt;

            if (registro.Fecha != null && registro.Fecha != string.Empty)
            {
                //fechaStr = registro.Fecha.Substring(0, registro.Fecha.IndexOf("T"));
                fechaStr = registro.Fecha + " " + registro.Hora;
                //fechaStr = fechaStr + " " + registro.Hora;
                fechaDt = DateTime.Parse(fechaStr);
                fechaDt = fechaDt.AddHours(-5);
                registro.Fecha = fechaDt.Date.ToString();
                registro.Hora = fechaDt.TimeOfDay;
                registro.Fecha = registro.Fecha.Substring(0, registro.Fecha.IndexOf(" "));
            }

            return registro;
        }

        /// <summary>
        /// Creates a dummy registro
        /// </summary>
        /// <param name="registroEntity"></param>
        /// <returns></returns>
        public IEnumerable<RegistroEntity> NotFound()
        {
            RegistroEntity registro = new RegistroEntity
            {
                Fecha = DateTime.Now.ToString(),
                Hora = DateTime.Now.TimeOfDay,
                IdItem = 0,
                //IdRegistro = null,
                IdUsuario = 0,
                Kilometraje = 0,
                Latitud = 4.7m,
                Longitud = -74.7m,
                TanqueConductor = 0,
                TanquePasajero = 0,
                Velocidad = 0,
                Usuario = null,
                Item = null
            };
            List<RegistroEntity> registroList = new List<RegistroEntity>();
            registroList.Add(registro);
            return registroList;
            
        }
    }
}
