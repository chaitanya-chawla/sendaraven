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

    public class DeveloperController : ApiController
    {

        // GET api/values/5
        [SwaggerOperation("GetByTenantId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public RegistrationResponse GetByTenantId(String tenantId)
        {
            return new RegistrationResponse();
        }

        // POST api/values
        [SwaggerOperation("Register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public RegistrationResponse Register([FromBody]RegistrationRequest request)
        {
            return new RegistrationResponse();
        }

    }
}
