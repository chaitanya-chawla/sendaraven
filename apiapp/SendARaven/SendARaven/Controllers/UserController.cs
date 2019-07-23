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


    /**
    * Note @{BaseURl} = /v1/api/user
    */
    public class UserController : ApiController
    {

        // GET /v1/api/user/GetByUserId
        [SwaggerOperation("GetByUserId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpGet]
        public RegisterUserRequest GetByUserId(String id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return new RegisterUserRequest();
        }

        // POST /v1/api/user/Register/
        [SwaggerOperation("Register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void Register([FromBody]RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

        // POST /v1/api/user/channelRegister/
        [SwaggerOperation("channelRegister")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void RegisterChannel([FromBody] RegisterUserChannelRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

    }
}
