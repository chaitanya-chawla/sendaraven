using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace sendaravendummy
{
    public class Program
    {
        static void Main(string[] args)
        {

            //send email
            TemplateFormat template = Template.getTemplate(ChannelType.Mail, Provider.SendGrid);
            var channelConfig = ChannelInformation.getConfiguration("a", ChannelType.Mail, Provider.SendGrid);
            Request request =new Request("Hi $user.firstName","Testing message", "chaitanyachawla1996@gmail.com");
            var requestConfig = getRequestConfig(request);

            var userConfig = User.getById("blah");
            Communicate.configureTemplate(template,channelConfig,userConfig,requestConfig);
            var response = Communicate.sendRequest(template).Result;
            Console.Out.WriteLine("done");

            //send message
            TemplateFormat template2 = Template.getTemplate(ChannelType.Sms, Provider.Msg91);
            var channelConfig2 = ChannelInformation.getConfiguration("a", ChannelType.Sms, Provider.Msg91);
            Request request2 = new Request("Hi $user.firstName", "Testing message", "8100408210");
            var requestConfig2 = getRequestConfig(request2);

            var userConfig2 = User.getById("blah");
            Communicate.configureTemplate(template2, channelConfig2, userConfig2, requestConfig2);
            var response2 = Communicate.sendRequest(template2).Result;
            Console.Out.WriteLine("done");
        }

        public static Dictionary<string, string> getRequestConfig(Request request)
        {
            Dictionary<string, string> requestConfig = new Dictionary<string, string>();
            if (request.textBody != null)
            {
                requestConfig.Add("textBody", request.textBody);

            }

            if (request.subject != null)
            {
                requestConfig.Add("subject", request.subject);
            }

            if (request.channelId != null)
            {
                requestConfig.Add("channelId", request.channelId);
            }

            return requestConfig;
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
            string emailbody =
            "{\r\n  \"personalizations\": [\r\n    {\r\n      \"to\": [\r\n        {\r\n          \"email\": \"$req-user.channelId\"\r\n        }\r\n      ],\r\n      \"subject\": \"$req.subject\"\r\n    }\r\n  ],\r\n  \"from\": {\r\n    \"email\": \"$config.senderId\"\r\n  },\r\n  \"content\": [\r\n    {\r\n      \"type\": \"text/plain\",\r\n      \"value\": \"$req.textBody\"\r\n    }\r\n  ]\r\n}";
            Dictionary<string, string> emailheader = new Dictionary<string, string>
            {
                {"Authorization", "Bearer $config.apiKey"},
                {"content-type", "application/json"}
            };

            TemplateFormat emailTemplateFormat = new TemplateFormat(emailheader, emailbody, HttpMethod.Post, "https://api.sendgrid.com/v3/mail/send", new List<string> { "apiKey", "senderId" });

            string smsbody =
                "{\r\n  \"sender\": \"$config.senderId\",\r\n  \"route\": \"4\",\r\n  \"country\": \"91\",\r\n  \"sms\": [\r\n    {\r\n      \"message\": \"$req.textBody\",\r\n      \"to\": [\r\n        \"$req-user.channelId\"\r\n      ]\r\n    }\r\n  ]\r\n}";

            Dictionary<string, string> smsheader = new Dictionary<string, string>
            {
                {"authkey", "$config.apiKey"},
                {"content-type", "application/json"}
            };

            TemplateFormat smsTemplateFormat = new TemplateFormat(smsheader, smsbody, HttpMethod.Post, "https://api.msg91.com/api/v2/sendsms?country=91", new List<string> { "apiKey", "senderId" });

            if (type == ChannelType.Mail)
            {
                return emailTemplateFormat;
            }
            return smsTemplateFormat;
        }
    }

    public class Request
    {
        public string textBody;
        public string subject;
        public string channelId;

        public Request(string textBody, string subject, string channelId)
        {
            this.textBody = textBody;
            this.subject = subject;
            this.channelId = channelId;
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
            var emailConfig = new Dictionary<string, string>
            {
                {"apiKey", "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"},
                {"senderId", "testuser@example.com"}
            };

            var smsConfig = new Dictionary<string, string>
            {
                {"apiKey", "286355ArYeDDLx4EFP5d367ce1"},
                {"senderId", "TestId"}
            };

            if (channelType == ChannelType.Mail)
                return emailConfig;
            return smsConfig;
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
        string userId;
        string tenantId;
        Dictionary<string, string> attributes;

        User(string userId, string tenantId, Dictionary<string, string> attributes)
        {
            this.userId = userId;
            this.tenantId = tenantId;
            this.attributes = attributes;
        }

        public static Dictionary<string, string> getById(string userId)
        {
            var attributes = new Dictionary<string, string>
            {
                {"firstName", "Chaitanya"},
                {"lastName", "Chawla"}
            };
            return attributes;
        }
    }

    public class Communicate
    {

        public static HttpClient client;

        public static async Task<ResponseStatus> sendRequest(TemplateFormat template)
        {
            var client = new RestClient(template.url);
            var request = new RestRequest(Method.POST);
            foreach (var header in template.header)
            {
                request.AddHeader(header.Key, header.Value);
            }
            request.AddParameter("application/json", template.body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.ResponseStatus;
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

        public static void configureTemplate(TemplateFormat template, Dictionary<string, string> channelConfig, Dictionary<string, string> userConfig, Dictionary<string, string> requestConfig)
        {
            
            configureTemplate(template, requestConfig, "req");
            configureTemplate(template, requestConfig, "req-user");
            configureTemplate(template, userConfig, "req-user");
            configureTemplate(template, userConfig, "user");
            configureTemplate(template, channelConfig, "config");
        }



    }





}


