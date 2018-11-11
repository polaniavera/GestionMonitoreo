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
    [RoutePrefix("api/conductor")]
    public class ConductorController : ApiController
    {
        private readonly ConductorServices _conductorServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize registro service instance
        /// </summary>
        public ConductorController()
        {
            _conductorServices = new ConductorServices();
        }

        #endregion

        // POST api/conductor/create
        [Route("create")]
        public int Post([FromBody] ConductorEntity conductorEntity)
        {
            if (conductorEntity != null)
            {
                return _conductorServices.CreateConductor(conductorEntity);
            }
            return 0;
        }
    }
}
