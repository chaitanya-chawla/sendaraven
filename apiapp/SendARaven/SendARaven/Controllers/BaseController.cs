using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers
{
    using System.IdentityModel.Protocols.WSTrust;
    using System.Web.Http;
    using Models;

    public class BaseController : ApiController
    {


        public HeaderRequestBase GetHeaders( Boolean shouldThrowException = true)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("apiKey"))
            {
                string apiKey = headers.GetValues("apiKey").First();
                string tenantId = headers.GetValues("tenantId").First();

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


        public void GetHeaders(HeaderRequestBase request,Boolean shouldThrowException = true )
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("apiKey"))
            {
                string apiKey = headers.GetValues("apiKey").First();
                string tenantId = headers.GetValues("tenantId").First();

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