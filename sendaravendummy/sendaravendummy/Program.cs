using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace sendaravendummy
{
    public class Program
    {
        static void Main(string[] args)
        {
            TemplateFormat template = Template.getTemplate(ChannelType.Mail, Provider.SendGrid);
            var channelConfig = ChannelInformation.getConfiguration("a", ChannelType.Mail, Provider.SendGrid);
            Communicate.configureTemplate(template, channelConfig, "config");
            Console.Out.WriteLine(template.header.ToString());
            Console.Out.WriteLine(template.body);
            
        }

        static async Task Execute()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with Twilio SendGrid is Fun";
            var to = new EmailAddress("chaitanyachawla1996@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }

    public enum ChannelType
    {
        Mail,
        Sms
    }

    public enum Provider
    {
        SendGrid,
        Msg91
    }

    public class TemplateFormat
    {
        public Dictionary<string, string> header;
        public string body;
        public string url;
        public HttpMethod method;
        public List<string> mandatoryConfigKeys;

        public TemplateFormat(Dictionary<string, string> header, string body, HttpMethod method, string url, List<string> mandatoryConfigKeys)
        {
            this.header = header;
            this.body = body;
            this.method = method;
            this.url = url;
            this.mandatoryConfigKeys = mandatoryConfigKeys;
        }
    }

    

    public class Template
    {
        public string TemplateId;
        public ChannelType channelType;
        public Provider provider;
        public int status;
        public TemplateFormat templateFormat;
        
        public static TemplateFormat getTemplate(ChannelType type, Provider provider)
        {
            string body =
                "{\r\n  \"personalizations\": [\r\n    {\r\n      \"to\": [\r\n        {\r\n          \"email\": \"${req-usr.channelId}\"\r\n        }\r\n      ],\r\n      \"subject\": \"${req.subject}\"\r\n    }\r\n  ],\r\n  \"from\": {\r\n    \"email\": \"$config.senderId\"\r\n  },\r\n  \"content\": [\r\n    {\r\n      \"type\": \"text/plain\",\r\n      \"value\": \"${req.body}\"\r\n    }\r\n  ]\r\n}";
            Dictionary<string, string> header = new Dictionary<string, string>
            {
                {"Authorization", "Bearer $config.apiKey"},
                {"Content - Type", "application / json"}
            };
            return new TemplateFormat(header, body, HttpMethod.Post, "https://api.sendgrid.com/v3/mail/send", new List<string>{ "apiKey", "senderId" });
        }
    }

    public class ChannelInformation
    {
        string TenantId;
        ChannelType ChannelType;
        Provider provider;
        string ChannelName;
        Dictionary<string, string> config;

        public static Dictionary<string, string> getConfiguration(string tenantId, ChannelType channelType, Provider provider)
        {
            return new Dictionary<string, string>
            {
                {"apiKey", "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"},
                {"senderId", "ravenTesting@microsoft.com"}
            };
        }

    }

    public class UserChannel
    {
        string userid;
        string tenantid;
        string channelname;
        Provider provider;
        ChannelType type;
        string channelId;

        public string getChannelId(string tenantId, ChannelType channelType, Provider provider, string userId)
        {
            return "chaitanyachawla1996@gmail.com";
        }
    }

    public class User
    {
        public string firstName;
        string lastName;
        string userId;
        string tenantId;
         Dictionary<string, string> attributes;

        User(string firstName, string lastName, string userId, string tenantId, Dictionary<string, string> attributes)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userId = userId;
            this.tenantId = tenantId;
            this.attributes = attributes;
        }

        public static User getById(string userId)
        {
            return new User("Chaitanya", "Chawla", "1", "t1", null);
        }
    }

    public class Communicate
    {

        public static readonly HttpClient client = new HttpClient();

        public HttpResponseMessage sendRequest(TemplateFormat format)
        {
            // send request
            return null;
        }

        public static void configureTemplate(TemplateFormat template, Dictionary<string, string> config, string prefix)
        {
            foreach (var pair in config)
            {
                string toReplace = $"${prefix}.{pair.Key}";
                template.body=template.body.Replace(toReplace, pair.Value);
                var keys = new List<string>(template.header.Keys);
                foreach (var key in keys)
                {
                    template.header.TryGetValue(key,out var value);
                    value=value.Replace(toReplace, pair.Value);
                    template.header[key] = value;
                }
            }
        }

        public static void configureTemplate(TemplateFormat template, Dictionary<string, string> channelConfig, Dictionary<string, string> requestConfig, string channelId)
        {
            
            configureTemplate(template, channelConfig, "config");
        
        }



    }





}


