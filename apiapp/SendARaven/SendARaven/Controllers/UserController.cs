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
        public UserEntity GetByUserId(String id)
        {
            GetHeaders();
            var tenantId = Request.Headers.GetValues("x-tenant-id").First();
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return dbCoreService.GetUserEntity(id, tenantId);
        }

        // POST /v1/api/user/Register/
        [SwaggerOperation("register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void Register([FromBody]RegisterUserRequest request)
        {
            GetHeaders(request);
            var tenantId = Request.Headers.GetValues("x-tenant-id").First();
            UserEntity user = new UserEntity(request.userId, tenantId, request.attributes);
            using (var context = new EntityDbContext())
            {
                context.UserEntities.Add(user);
                context.SaveChanges();
            }
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
            var tenantId = Request.Headers.GetValues("x-tenant-id").First();
            var userChannelInformation = new UserChannelInformation(request.ChannelType, request.UserChannelId, request.UserId, tenantId);
            using (var context = new EntityDbContext())
            {
                context.UserChannelInformations.Add(userChannelInformation);
                context.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

    }
}
