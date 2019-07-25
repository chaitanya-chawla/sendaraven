using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SendARaven.Controllers.service;
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

        private DBCoreService dbCoreService = new DBCoreService();

        //API END POINT => /v1/api/channel/Register
        [SwaggerOperation("Register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.OK)]
        public ChannelEntity Register([FromBody]RegisterChannelRequest request)
        {

            var tenantId = Request.Headers.GetValues("x-tenant-id").First();
            var channelEntity = new ChannelEntity(tenantId, request.ChannelName, request.ChannelType, request.TemplateId, request.ChannelProvider, 1, request.ChannelConfig);
            using (var context = new EntityDbContext())
            {
                context.ChannelEntities.Add(channelEntity);
                context.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return null;
        }


        //API END POINT => /v1/api/channel/List
        [SwaggerOperation("List")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.Created)]
        public List<ChannelEntity> List()
        {
            List<ChannelEntity> channels;
            var tenantId = Request.Headers.GetValues("x-tenant-id").First();
            using (var context = new EntityDbContext())
            {
                channels = context.ChannelEntities.Where(channel=>channel.TenantId==tenantId).ToList();
            }

            return channels;
        }

    }
}
