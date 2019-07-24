using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class ChannelEntity
    {

        public String TenantId { get; set; }
        public String ChannelName { get; set; }
        public Enums.ChannelType ChannelType { get; set; }
        public String TemplateId { get; set; }
        public Enums.ChannelProvider ChannelProvider;
        public int Status;
        public Dictionary<String, Object> ChannelConfig { get; set; }

    }
}