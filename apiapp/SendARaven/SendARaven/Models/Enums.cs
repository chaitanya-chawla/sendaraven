using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class Enums
    {
        public enum ChannelType
        {
            Sms,
            Email
        }

        public enum ChannelProvider
        {
            Sendgrid,
            Msg91
        }
    }
}