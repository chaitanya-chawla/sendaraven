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

        [Required]
        public String templateId { get; set; }

        [Required]
        public String endpointType { get; set; }

        [Required]
        public Dictionary<String, Object> cfg { get; set; }

    }
}