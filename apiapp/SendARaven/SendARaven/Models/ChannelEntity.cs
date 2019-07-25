using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SendARaven.Models
{
    [Table("channel_entity")]
    public class ChannelEntity
    {
        public ChannelEntity(string tenantId, string channelName, Enums.ChannelType channelType, string templateId,
            Enums.ChannelProvider channelProvider, int status, Dictionary<string, string> channelConfig)
        {
            TenantId = tenantId;
            ChannelName = channelName;
            ChannelType = channelType;
            TemplateId = templateId;
            ChannelProvider = channelProvider;
            Status = status;
            ChannelConfig = channelConfig;
        }

        public ChannelEntity(string tenantId, string channelName, Enums.ChannelType channelType, string templateId,
            Enums.ChannelProvider channelProvider, int status)
        {
            TenantId = tenantId;
            ChannelName = channelName;
            ChannelType = channelType;
            TemplateId = templateId;
            ChannelProvider = channelProvider;
            Status = status;
        }

        //public ChannelEntity(string tenantId, string channelName, Enums.ChannelType channelType, string templateId,
        //    Enums.ChannelProvider channelProvider, int status, String channelConfig)
        //{
        //    TenantId = tenantId;
        //    ChannelName = channelName;
        //    ChannelType = channelType;
        //    TemplateId = templateId;
        //    ChannelProvider = channelProvider;
        //    Status = status;
        //    chanconfig = channelConfig;

        //}

        [StringLength(128), Column("tenantId")]
        public String TenantId { get; set; }

        [StringLength(128), Column("channelName")]
        public String ChannelName { get; set; }

        [Column("channelType")]
        public Enums.ChannelType ChannelType { get; set; }

        [StringLength(128), Column("templateId")]
        public String TemplateId { get; set; }

        [Column("channelProvider")]
        public Enums.ChannelProvider ChannelProvider { get; set; }

        [Column("status")]
        public int Status { get; set; }
        
        [Column("channelConfig")]
        public String chanconfig
        {
            get { return JsonConvert.SerializeObject(ChannelConfig); }

            set
            {
                
                    ChannelConfig = JsonConvert.DeserializeObject<Dictionary<String, String>>(value);
            }
        }

        [NotMapped]
        public Dictionary<String, String> ChannelConfig { get; set; }

    }
}