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

    public class ChannelController : ApiController
    {

        // GET api/values/5
        [SwaggerOperation("GetByChannelId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public RegisterChannel GetByUserId(String channelId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new RegisterChannel();
        }

        // POST api/values
        [SwaggerOperation("Post")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public RegisterChannel Post([FromBody]RegisterChannelRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new RegisterChannel();
        }


        // POST api/values
        [SwaggerOperation("List")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpGet]
        public List<RegisterChannel> List()
        {
            return null;
        }

    }
}
