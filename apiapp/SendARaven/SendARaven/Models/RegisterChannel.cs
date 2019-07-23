using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class RegisterChannel
    {

        public String id { get; set; }
        public String name { get; set; }
        public String type { get; set; }
        public String templateId { get; set; }
        public String endpointType { get; set; }

        public Dictionary<String, Object> cfg { get; set; }

        public String templateEndpoint { get; set; }

        public Dictionary<String, Object> templateHeader { get; set; }

        public String templateBody { get; set; }
    }
}