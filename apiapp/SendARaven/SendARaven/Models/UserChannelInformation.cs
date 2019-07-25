using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class UserChannelInformation
    {

        public Enums.ChannelType ChannelType;
        public string UserChannelId;

        public UserChannelInformation(Enums.ChannelType channelType, string userChannelId)
        {
            ChannelType = channelType;
            UserChannelId = userChannelId;
        }
    }
}