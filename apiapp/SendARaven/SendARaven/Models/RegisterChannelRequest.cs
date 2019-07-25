using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterChannelRequest : HeaderRequestBase
    {
        [Required]
        public String ChannelName { get; set; }

        [Required]
        public Enums.ChannelType ChannelType { get; set; }

        [Required]
        public String TemplateId { get; set; }

        [Required]
        public Enums.ChannelProvider ChannelProvider { get; set; }
        

        [Required]
        public Dictionary<String, String> ChannelConfig { get; set; }

    }
}