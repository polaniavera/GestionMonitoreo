using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionMonitoreo.Controllers
{
    [RoutePrefix("api/registro")]
    public class RegistroController : ApiController
    {
        private readonly RegistroServices _registroServices;
        private readonly ItemServices _itemServices;
        private readonly UsuarioServices _usuarioServices;
        private readonly EstacionesServices _estacionesServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize registro service instance
        /// </summary>
        public RegistroController()
        {
            _registroServices = new RegistroServices();
            _itemServices = new ItemServices();
            _usuarioServices = new UsuarioServices();
            _estacionesServices = new EstacionesServices();
        }

        #endregion

        // GET api/registro
        public HttpResponseMessage Get()
        {
            var registros = _registroServices.GetAllRegistros();
            if (registros != null)
            {
                registros = _registroServices.formatRegistros(registros);
                var registroEntities = registros as List<RegistroEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registros not found");
        }

        // GET api/registro/5
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var registro = _registroServices.GetRegistroById(id);
            if (registro != null)
            {
                registro = _registroServices.formatRegistro(registro);
                return Request.CreateResponse(HttpStatusCode.OK, registro);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registro found for this id");
        }

        //GET api/registro/getByUser/5/2017-03-03
        [Route("getByUser/{idUsuario?}/{fecha?}")]
        public HttpResponseMessage GetByIdUsuario(string idUsuario, string fecha)
        {
            var registros = _registroServices.GetByIdUsuario(idUsuario, fecha);
            if (registros != null)
            {
                registros = _registroServices.formatRegistros(registros);
                var registroEntities = registros as List<RegistroEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registros found for this idUsuario and Date");
        }

        //GET api/registro/getByItem/1/2/2017-03-03
        [Route("getByItem/{idUsuario?}/{idItem?}/{fecha?}")]
        public HttpResponseMessage GetByIdItem(string idUsuario, string idItem, string fecha)
        {
            var registros = _registroServices.GetByIdItem(idUsuario, idItem, fecha);
            if (registros != null)
            {
                registros = _registroServices.formatRegistros(registros);
                var registroEntities = registros as List<RegistroEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registros found for this item and Date");
            //var registrosDefault = _registroServices.NotFound();
            //return Request.CreateResponse(HttpStatusCode.OK, registrosDefault);                        
        }

        //GET api/registro/getByItemRange/1/2/2017-04-23/2017-04-28
        [Route("getByItemRange/{idUsuario?}/{idItem?}/{fechaInicial?}/{fechaFinal?}")]
        public HttpResponseMessage GetByIdItemRange(string idUsuario, string idItem, string fechaInicial, string fechaFinal)
        {
            var registros = _registroServices.GetByIdItemRange(idUsuario, idItem, fechaInicial, fechaFinal);
            if (registros != null)
            {
                registros = _registroServices.formatRegistros(registros);
                var registroEntities = registros as List<RegistroEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registros found for this idUsuario, idItem and Date");
        }

        //GET api/registro/getDashboard/1
        [Route("getDashboard/{idUsuario?}")]
        public HttpResponseMessage GetDashboard(string idUsuario)
        {
            var usuario = _usuarioServices.GetUserById(idUsuario);
            var items = _itemServices.GetItemByUser(idUsuario);
            var registros = _registroServices.GetDashboard(idUsuario);

            if (registros != null && items != null && usuario != null)
            {
                registros = _registroServices.formatRegistros(registros);

                var vehiculos = _itemServices.SetVehiculos(items, registros);

                var vehiculoEntities = vehiculos as List<VehiculosEntity> ?? vehiculos.ToList();

                object[] jsonArray = { usuario, vehiculoEntities };

                return Request.CreateResponse(HttpStatusCode.OK, jsonArray);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registros found for this idUsuario, idItem and Date");
        }

        //GET api/registro/getDashboardByDate/1/2017-04-22
        [Route("getDashboardByDate/{idUsuario?}/{fecha?}")]
        public HttpResponseMessage getDashboardByDate(string idUsuario, string fecha)
        {
            var registros = _registroServices.GetDashboardByDate(idUsuario, fecha);
            if (registros != null)
            {
                registros = _registroServices.formatRegistros(registros);
                var registroEntities = registros as List<RegistroEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registros found for this idUsuario, idItem and Date");
        }

        // POST api/registro/create
        [Route("create")]
        public int Post([FromBody] RegistroEntity registroEntity)
        {
            if(registroEntity!=null)
            {
                return _registroServices.CreateRegistro(registroEntity);
            }
            return 0;
        }

        // PUT api/registro/5
        public bool Put(int id, [FromBody]RegistroEntity registroEntity)
        {
            if (id > 0)
            {
                return _registroServices.UpdateRegistro(id, registroEntity);
            }
            return false;
        }

        // DELETE api/registro/5
        [Route("delete/{id?}")]
        public bool Delete(int id)
        {
            if (id > 0)
                return _registroServices.DeleteRegistro(id);
            return false;
        }

        // GET api/marcas
        [Route("estaciones")]
        public HttpResponseMessage GetEstaciones()
        {
            var estaciones = _estacionesServices.GetAllEstaciones();
            if (estaciones != null)
            {
                var estacionesEntities = estaciones as List<EstacionesEntity> ?? estaciones.ToList();
                if (estacionesEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, estacionesEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "estaciones not found");
        }
    }
}
