using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterChannelRequest
    {
        [Required]
        public String name { get; set; }

        [Required]
        public String type { get; set; }

        public String templateId { get; set; }

        public String endpointType { get; set; }

        [Required]
        public Dictionary<String, Object> cfg { get; set; }

        public String templateEndpoint { get; set; }

        [Required]
        public Dictionary<String, Object> templateHeader { get; set; }

        public String templateBody { get; set; }
    }
}