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
    public class RegistroController : ApiController
    {

        private readonly IRegistroServices _registroServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize registro service instance
        /// </summary>
        public RegistroController()
        {
            _registroServices = new RegistroServices();
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

        // POST api/registro
        //public int Post([FromBody] RegistroEntity registroEntity)
        //{
        //    return _registroServices.CreateRegistro(registroEntity);
        //}

        public int Post(decimal latitud, decimal longitud, decimal tanqueConductor,
            decimal tanquePasajero, bool botonPanico, decimal kilometraje,
            decimal velocidad, DateTime fecha, TimeSpan hora, int idUsuario, int idItem)
        {
            return _registroServices.CreateRegistroUrl(latitud, longitud, tanqueConductor,
                tanquePasajero, botonPanico, kilometraje, velocidad, fecha, hora, idUsuario, idItem);
        }
        
        public int Post(string latitud, string longitud, string tanqueConductor,
            string tanquePasajero, string botonPanico, string kilometraje,
            string velocidad, string fecha, string hora, string idUsuario, string idItem)
        {
            return _registroServices.CreateRegistroUrl(latitud, longitud, tanqueConductor,
                tanquePasajero, botonPanico, kilometraje, velocidad, fecha, hora, idUsuario, idItem);
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
        public bool Delete(int id)
        {
            if (id > 0)
                return _registroServices.DeleteRegistro(id);
            return false;
        }
    }
}
