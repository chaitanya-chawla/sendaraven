using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    [Table("channel_entity")]
    public class ChannelEntity
    {
        [Key]
        public String ChannelId { get; set; }

        [StringLength(128), Column("tenantId")]
        public String TenantId { get; set; }

        [StringLength(128), Column("channelName")]
        public String ChannelName { get; set; }

        [Column("channelType")]
        public Enums.ChannelType ChannelType { get; set; }

        [StringLength(128), Column("templateId")]
        public String TemplateId { get; set; }

        [Column("channelProvider")]
        public Enums.ChannelProvider ChannelProvider;

        [StringLength(128), Column("status")]
        public int Status;

        public ChannelEntity(string id, string tenantId, string channelName, Enums.ChannelType channelType, string templateId,
            Enums.ChannelProvider channelProvider, int status, Dictionary<string, string> channelConfig)
        {
            ChannelId = id;
            TenantId = tenantId;
            ChannelName = channelName;
            ChannelType = channelType;
            TemplateId = templateId;
            ChannelProvider = channelProvider;
            Status = status;
            ChannelConfig = channelConfig;
        }

        [StringLength(128), Column("channelConfig")]
        public Dictionary<String, String> ChannelConfig { get; set; }

    }
}