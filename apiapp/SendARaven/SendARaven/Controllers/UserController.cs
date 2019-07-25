using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace SendARaven.Controllers
{
    using System.IdentityModel.Protocols.WSTrust;
    using System.IO;
    using System.Web.Services.Protocols;
    using Models;
    using service;


    /**
    * Note @{BaseURl} = /v1/api/user
    */

    [RoutePrefix("v1/api/user")]
    public class UserController : BaseController
    {
        protected DBCoreService dbCoreService;


        public UserController()
        {
            this.dbCoreService = new DBCoreService();
        }

        // GET /v1/api/user/GetByUserId
        [SwaggerOperation("GetByUserId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public UserEntity GetByUserId(String id)
        {
            GetHeaders();
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return dbCoreService.GetUserEntity(id);
        }

        // POST /v1/api/user/Register/
        [SwaggerOperation("register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        [Route("register")]
        public void Register([FromBody]RegisterUserRequest request)
        {
            GetHeaders(request);
            dbCoreService.SaveUserEntity();
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

        // POST /v1/api/user/channelRegister/
        [SwaggerOperation("channelRegister")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        [Route("channelRegister")]
        public void RegisterChannel([FromBody] RegisterUserChannelRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

    }
}
