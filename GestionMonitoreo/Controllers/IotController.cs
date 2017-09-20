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
    [RoutePrefix("api/iot")]
    public class IotController : ApiController
    {
        private readonly IotServices _iotServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize iot service instance
        /// </summary>
        public IotController()
        {
            _iotServices = new IotServices();
        }

        #endregion

        // GET api/iot
        public HttpResponseMessage Get()
        {
            var registros = _iotServices.GetAllRegistros();
            if (registros != null)
            {
                //registros = _iotServices.formatRegistros(registros);
                var registroEntities = registros as List<IotTemperaturaEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registros iot not found");
        }

        // GET api/iot/5
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var registro = _iotServices.GetRegistroById(id);
            if (registro != null)
            {
                //registro = _iotServices.formatRegistro(registro);
                return Request.CreateResponse(HttpStatusCode.OK, registro);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registro iot found for this id");
        }

        //GET api/iot/getByFecha/2017-03-03
        [Route("getByFecha/{fecha?}")]
        public HttpResponseMessage GetByFecha(string fecha)
        {
            var registros = _iotServices.GetByFecha(fecha);
            if (registros != null)
            {
                //registros = _iotServices.formatRegistros(registros);
                var registroEntities = registros as List<IotTemperaturaEntity> ?? registros.ToList();
                if (registroEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, registroEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No registros iot found for this Date");
        }

        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************

        // POST api/registro/iot
        [Route("create/{data?}")]
        public int PostIot(string data)
        {
            if (data != null || data.Equals(string.Empty))
            {
                return _iotServices.CreateIot(data);
            }
            return 0;
        }

        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************
    }
}
