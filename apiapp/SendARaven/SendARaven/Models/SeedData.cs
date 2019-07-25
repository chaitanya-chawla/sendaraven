using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class DummyObjects
    {
        public static string api_Key = "key_1";
        public static string tenantId = "tenant_1";

        public static TenantDetailsEntity tenant = new TenantDetailsEntity(api_Key, tenantId,
            "chaitanyachawla@yahoo.co.in", "Microsoft");

        public static Dictionary<string, string> attributes = new Dictionary<string, string> {{"City", "Bangalore"}};

        public static UserEntity user1 = new UserEntity("user_1", tenantId, attributes);

        public static UserEntity user2 = new UserEntity("user_2", tenantId, attributes);
            

        public static UserChannelInformation user1Channel1 = new UserChannelInformation(Enums.ChannelType.Email,
            "chaitanyachawla1996@gmail.com", "user_1", tenantId);

        public static UserChannelInformation user1Channel2 = new UserChannelInformation(Enums.ChannelType.Sms,
            "9717795767", "user_1", tenantId);

        public static UserChannelInformation user2Channel1 = new UserChannelInformation(Enums.ChannelType.Email,
            "ashima.wadha.1996@gmail.com", "user_2", tenantId);


        public static Dictionary<string, string> mailConfig = new Dictionary<string, string>
        {
            {"senderId", "test@example.com"},
            {"apiKey", "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"}
        };

        public static Dictionary<string, string> smsConfig = new Dictionary<string, string>
        {
            {"senderId", "TestId"},
            {"apiKey", "286355ArYeDDLx4EFP5d367ce1"}
        };

        public static ChannelEntity smsChannel = new ChannelEntity(tenantId, "sms-t", Enums.ChannelType.Sms,
            "sms_msg91", Enums.ChannelProvider.Msg91, 1, smsConfig);

        public static ChannelEntity emailChannel = new ChannelEntity(tenantId, "mail", Enums.ChannelType.Email,
            "mail_sendgrid", Enums.ChannelProvider.Sendgrid, 1, mailConfig);

    }
}