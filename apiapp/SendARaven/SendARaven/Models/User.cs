using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("developer")]
    public class User
    {
        public string UserId;
        public string TenantId;
        public Dictionary<string, string> Attributes;
        public List<UserChannelInformation> ChannelsInformation;
    }
}