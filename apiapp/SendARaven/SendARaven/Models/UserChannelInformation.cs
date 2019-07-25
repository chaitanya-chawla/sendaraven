using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class UserChannelInformation
    {
        public Enums.ChannelType ChannelType { get; set; }
        public Enums.ChannelProvider ChannelProvider { get; set; }
        public string UserChannelId { get; set; }

        public UserChannelInformation(Enums.ChannelType channelType, Enums.ChannelProvider channelProvider, string userChannelId)
        {
            ChannelType = channelType;
            ChannelProvider = channelProvider;
            UserChannelId = userChannelId;
        }
    }
}