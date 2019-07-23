using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace SendARaven.Controllers
{
    using System.Web.Services.Protocols;
    using Models;
    using Swashbuckle.Application;

    /**
     * Note @{BaseURl} = /v1/api/developer
     */
    public class DeveloperController : ApiController
    {

        // GET /v1/api/developer/GetByTenantId/
        [SwaggerOperation("GetByTenantId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public DeveloperRegisterEntity GetByTenantId(String tenantId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new DeveloperRegisterEntity();
        }

        // POST /v1/api/developer
        [SwaggerOperation("Register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public DeveloperRegisterEntity Register( [FromBody]ResisterDeveloperRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new DeveloperRegisterEntity();
        }

    }
}
