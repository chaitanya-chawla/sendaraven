using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class UserChannelEntity
    {
        public string Userid;
        public string tenantId;
        public Enums.ChannelType ChannelType;
        public string ChannelId;
        public string ChannelName;

    }
}