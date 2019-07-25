using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SendARaven.Models
{
    using System;
    using Newtonsoft.Json;


    [Table("myuser")]
    public class UserEntity
    {
        public UserEntity()
        {
            ChannelsInformation=new List<UserChannelInformation>();
        }

        public UserEntity(string userId, string tenantId, Dictionary<string, string> attributes)
        {
            UserId = userId;
            Attributes = attributes;
            TenantId = tenantId;
            ChannelsInformation=new List<UserChannelInformation>();
        }

        [Required, Column("tenantId")]
        public string TenantId { get; set; }

        [Required, Column("userId")]
        public string UserId { get; set; }
        
        // The JSON column
        [Required , Column("attributes")]
        public String atr
        {
            get { return JsonConvert.SerializeObject(Attributes); }

        set
            {
                Attributes = JsonConvert.DeserializeObject<Dictionary<String, String>>(value); 
            }
        }

        [NotMapped]
        public Dictionary<string, string> Attributes { get; set; }

        //[Required, Column("channelsInformation")]
        //public String channelInfo
        //{
        //    get { return JsonConvert.SerializeObject(ChannelsInformation); }

        //    set
        //    {
        //        ChannelsInformation = JsonConvert.DeserializeObject<List<UserChannelInformation>>(value);
        //    }
        //}
        
        [NotMapped]
        public List<UserChannelInformation> ChannelsInformation { get; set; }
    }
}