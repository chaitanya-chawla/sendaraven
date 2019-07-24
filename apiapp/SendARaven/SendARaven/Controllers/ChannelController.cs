using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace SendARaven.Controllers
{
    using System.Collections;
    using System.Web.Services.Protocols;
    using Models;

    /**
     * Note @{BaseURl} = /v1/api/channel
     */
    public class ChannelController : ApiController
    {

        //API END POINT  => /v1/api/channel/GetByUserId
        [SwaggerOperation("GetByChannelId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public ChannelEntity GetByChannelId(String id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new ChannelEntity();
        }

        //API END POINT => /v1/api/channel/Register
        [SwaggerOperation("Register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        public ChannelEntity Register([FromBody]RegisterChannelRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new ChannelEntity();
        }


        //API END POINT => /v1/api/channel/List
        [SwaggerOperation("List")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.Created)]
        public List<ChannelEntity> List()
        {
            return null;
        }

    }
}
