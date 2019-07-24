using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class Recipients
    {
        public string UserId;
        public Dictionary<string, string> Attributes;
        public List<Enums.ChannelType> ChannelTypes;
        public List<UserChannelInformation> Guests;
    }
}