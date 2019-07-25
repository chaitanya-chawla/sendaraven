using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserChannelRequest
    {
        public String UserId { get; set; }
        public Enums.ChannelType ChannelType { get; set; }
        public String UserChannelId { get; set; }
    }
}