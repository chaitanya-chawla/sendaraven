using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class ChannelEntity
    {

        public String id { get; set; }
        public String name { get; set; }
        public String type { get; set; }
        public String templateId { get; set; }
        public String endpointType { get; set; }

        public Dictionary<String, Object> cfg { get; set; }

    }
}