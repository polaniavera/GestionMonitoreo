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
    [RoutePrefix("api/grupo")]
    public class GrupoController : ApiController
    {
        private readonly GrupoServices _grupoServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize grupo service instance
        /// </summary>
        public GrupoController()
        {
            _grupoServices = new GrupoServices();
        }

        #endregion

        //GET api/grupo/getGrupos/1
        [Route("getGrupos/{idUsuario?}")]
        public HttpResponseMessage getGrupos(string idUsuario)
        {
            var grupos = _grupoServices.GetGruposByUser(idUsuario);

            if (grupos != null)
            {
                var gruposEntities = grupos as List<GrupoEntity> ?? grupos.ToList();
                if (gruposEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, gruposEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No grupos found for this idUsuario");
        }

    }
}
