using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class Recipients
    {
        public string UserId { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public List<Enums.ChannelType> ChannelTypes { get; set; }
        public List<UserChannelInformation> Guests { get; set; }
    }
}