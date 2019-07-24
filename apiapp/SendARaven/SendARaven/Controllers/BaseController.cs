using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers
{
    using System.IdentityModel.Protocols.WSTrust;
    using System.Web.Http;
    using Models;
    using service;

    public abstract class BaseController : ApiController
    {


        protected HeaderRequestBase GetHeaders( Boolean shouldThrowException = true)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("x-api-key"))
            {
                string apiKey = headers.GetValues("x-api-key").First();
                string tenantId = headers.GetValues("x-tenant-id").First();

                HeaderRequestBase request = new HeaderRequestBase();
                request.apiKey = apiKey;
                request.tenantId = tenantId;
                return request;
            }
            else if (shouldThrowException)
            {
                throw new InvalidRequestException("Api key, tenant id should presents");
            }

            return null;

        }


        protected void GetHeaders(HeaderRequestBase request, Boolean shouldThrowException = true )
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("x-api-key"))
            {
                string apiKey = headers.GetValues("x-api-key").First();
                string tenantId = headers.GetValues("x-tenant-id").First();

                request.apiKey = apiKey;
                request.tenantId = tenantId;
            }
            else if(shouldThrowException)
            {
                throw new InvalidRequestException("Api key, tenant id should presents");
            }

        }

    }
}