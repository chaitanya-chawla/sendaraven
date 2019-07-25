using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    [Table("userchannelinfo")]
    public class UserChannelInformation
    {
        [Column("userId")]
        public string UserId{ get; set; }

        [Column("tenantId")]
        public string TenantId { get; set; }

        [Column("channelType")]
        public Enums.ChannelType ChannelType { get; set; }

        [Column("userChannelId")]
        public string UserChannelId { get; set; }

        public UserChannelInformation(Enums.ChannelType channelType, string userChannelId, string userId, string tenantId)
        {
            ChannelType = channelType;
            UserChannelId = userChannelId;
            UserId = userId;
            TenantId = tenantId;
        }
    }
}