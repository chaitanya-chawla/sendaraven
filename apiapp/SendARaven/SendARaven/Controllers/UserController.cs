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

    public class UserController : ApiController
    {

        // GET api/values/5
        [SwaggerOperation("GetByUserId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public RegisterUserRequest GetByUserId(String userId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new RegisterUserRequest();
        }

        // POST api/values
        [SwaggerOperation("Post")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

    }
}
