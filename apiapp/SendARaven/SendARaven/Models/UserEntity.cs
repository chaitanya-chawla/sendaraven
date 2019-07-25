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
        }

        public UserEntity(string userId, Dictionary<string, string> attributes, List<UserChannelInformation> channelsInformation, string tenantId)
        {
            UserId = userId;
            Attributes = attributes;
            ChannelsInformation = channelsInformation;
            TenantId = tenantId;
        }

        [Required, Display(Name = "userId"), Column("userId")]
        [Key]
        public string UserId { get; set; }

        [Required, Display(Name = "tenantId"),  Column("tenantId")]
        public string TenantId { get; set; }


      
        // The JSON column
        [Required , Display(Name = "attributes"), Column("attributes")]
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



        [NotMapped]
        public List<UserChannelInformation> ChannelsInformation { get; set; }
    }
}