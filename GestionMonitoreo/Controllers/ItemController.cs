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
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        private readonly ItemServices _itemServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize registro service instance
        /// </summary>
        public ItemController()
        {
            _itemServices = new ItemServices();
        }

        #endregion

        //GET api/item/getItems/1
        [Route("getItems/{idUsuario?}")]
        public HttpResponseMessage getItems(string idUsuario)
        {
            var items = _itemServices.GetItemByUser(idUsuario);

            if (items != null)
            {
                var itemsEntities = items as List<ItemEntity> ?? items.ToList();
                if (itemsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, itemsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No items found for this idUsuario");
        }

    }
}