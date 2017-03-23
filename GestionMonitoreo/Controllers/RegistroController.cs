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

        private readonly IRegistroServices _registroServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize registro service instance
        /// </summary>
        public RegistroController(IRegistroServices registroServices)
        {
            _registroServices = registroServices;
        }

        #endregion

        // GET api/registro
        public HttpResponseMessage Get()
        {
            var registros = _registroServices.GetAllRegistros();
            if (registros != null)
            {
                var registroEntities = registros as List<RegistroEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registros not found");
        }

        // GET api/registro/5
        public HttpResponseMessage Get(int id)
        {
            var registro = _registroServices.GetRegistroById(id);
            if (registro != null)
                return Request.CreateResponse(HttpStatusCode.OK, registro);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registro found for this id");
        }

        //GET api/registro/getByUser/5/2017-03-03
        [Route("getByUser/{idUsuario?}/{fecha?}")]
        public HttpResponseMessage GetByIdUsuario(string idUsuario, string fecha)
        {
            var registros = _registroServices.GetByIdUsuario(idUsuario, fecha);
            if (registros != null)
            {
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
            return _registroServices.CreateRegistro(registroEntity);
        }


        [Route("prueba")]
        public int Prueba([FromBody] Test testEntity)
        {
            return _registroServices.CreateRegistroPrueba(testEntity);
        }


        // POST api/registro/create/...
        //[Route("create/{latitud?}/{longitud?}/{tanqueConductor?}/{tanquePasajero?}/{botonPanico?}/{velocidad?}/{idUsuario?}/{idItem?}")]
        //public int Post(string latitud, string longitud, string tanqueConductor,
        //    string tanquePasajero, string botonPanico, string velocidad, string idUsuario, string idItem)
        //{
        //    return _registroServices.CreateRegistroUrl(latitud, longitud, tanqueConductor,
        //        tanquePasajero, botonPanico, velocidad, idUsuario, idItem);
        //}

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
    }
}
