using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class DummyObjects
    {
        public static string api_Key = "06dc237f-68e6-4932-9e2b-a240291b19d6";
        public static string tenantId = "06dc237f-68e6-4932-9e2b-a289791b19d6";

        public static DeveloperRegisterEntity tenant = new DeveloperRegisterEntity(api_Key, tenantId,
            "chaitanyachawla@yahoo.co.in", "Microsoft", "Microsoft");

        public static Dictionary<string,string> attributes=new Dictionary<string, string>{{"City","Bangalore"}};



        public static User1 getUser2()
        {
            return new User1("user_2", attributes,
                new List<UserChannelInformation>
                {
                    new UserChannelInformation
                        (Enums.ChannelType.Email, Enums.ChannelProvider.Sendgrid, "chaitanyachawla@yahoo.co.in")
                }, tenantId);
        }

        public static Dictionary<string,string> mailConfig = new Dictionary<string, string>
        {
            {"senderId","test@example.com" },
            { "apiKey","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"}
        };

        public static Dictionary<string, string> smsConfig = new Dictionary<string, string>
        {
            {"senderId","TestId" },
            { "apiKey","286355ArYeDDLx4EFP5d367ce1"}
        };

        public static ChannelEntity smsChannel=new ChannelEntity("1",tenantId,"sms",Enums.ChannelType.Sms,"sms_msg91",Enums.ChannelProvider.Msg91,1,smsConfig);

        public static ChannelEntity emailChannel = new ChannelEntity("2", tenantId, "email", Enums.ChannelType.Email, "mail_sendgrid", Enums.ChannelProvider.Sendgrid, 1, mailConfig);

        public static User1 getUser1()
        {
            return new User1("user_1", attributes,
                new List<UserChannelInformation>
                {
                    new UserChannelInformation
                        (Enums.ChannelType.Email, Enums.ChannelProvider.Sendgrid, "chaitanyachawla1996@gmail.com"),
                    new UserChannelInformation(Enums.ChannelType.Sms, Enums.ChannelProvider.Msg91, "9717795767")
                }, tenantId);
        }

    }

    public class SuccessResponse
    {
        public Boolean isSuccess { get; set; } = true;
        public string message { get; set; } = "Api Succeeded";

 
    }
}