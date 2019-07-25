using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SendARaven.Services;
using Swashbuckle.Swagger.Annotations;

namespace SendARaven.Controllers
{
    using System.Collections;
    using System.Web.Services.Protocols;
    using Models;

    /**
     * Note @{BaseURl} = /v1/api/message
     */
    public class MessageController : ApiController
    {

        //API END POINT => /v1/api/message/Send
        [SwaggerOperation("SendMessage")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        public async Task Send([FromBody]SendMessageRequest request)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var tenantId = Request.Headers.GetValues("x-tenant-id").First();
            SendMessageService service = new SendMessageService(tenantId);
            await service.SendMessages(request);
        }

    }
}
