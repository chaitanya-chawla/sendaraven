using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserChannelRequest
    {
        public String userId { get; set; }
        public String channelName { get; set; }
        public String channelType { get; set; }
        public String channelId { get; set; }
    }
}