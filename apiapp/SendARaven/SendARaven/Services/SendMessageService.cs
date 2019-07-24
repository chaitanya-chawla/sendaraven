using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SendARaven.Models;
using RestSharp;
using RestSharp.Extensions;

namespace SendARaven.Services
{
    public class SendMessageService
    {
        private static TemplateEntity smsTemplateEntity = new TemplateEntity()
        {
            TemplateId = "smsTemplate1",
            Body = "{\r\n  \"sender\": \"$config.senderId\",\r\n  \"route\": \"4\",\r\n  \"country\": \"91\",\r\n  \"sms\": [\r\n    {\r\n      \"message\": \"$req.textBody\",\r\n      \"to\": [\r\n        \"$req-user.userChannelId\"\r\n      ]\r\n    }\r\n  ]\r\n}",
            ChannelProvider = Enums.ChannelProvider.Msg91,
            ChannelType = Enums.ChannelType.Sms,
            Headers = new Dictionary<string, string>
            {
                {"authkey", "$config.apiKey"},
                {"content-type", "application/json"}
            },
            MandatoryConfigKeys = new List<string> { "apiKey", "senderId" },
            Status = 1,
            UrlEndpoint = "https://api.msg91.com/api/v2/sendsms?country=91",
            UrlMethod = Method.POST
        };

        private static TemplateEntity emailTemplateEntity = new TemplateEntity()
        {
            TemplateId = "emailTemplate1",
            Body = "{\r\n  \"personalizations\": [\r\n    {\r\n      \"to\": [\r\n        {\r\n          \"email\": \"$req-user.userChannelId\"\r\n        }\r\n      ],\r\n      \"subject\": \"$req.subject\"\r\n    }\r\n  ],\r\n  \"from\": {\r\n    \"email\": \"$config.senderId\"\r\n  },\r\n  \"content\": [\r\n    {\r\n      \"type\": \"text/plain\",\r\n      \"value\": \"$req.textBody\"\r\n    }\r\n  ]\r\n}",
            ChannelProvider = Enums.ChannelProvider.Sendgrid,
            ChannelType = Enums.ChannelType.Email,
            Headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer $config.apiKey"},
                {"content-type", "application/json"}
            },
            MandatoryConfigKeys = new List<string> { "apiKey", "senderId" },
            Status = 1,
            UrlEndpoint = "https://api.sendgrid.com/v3/mail/send",
            UrlMethod = Method.POST
        };

        private static List<User1> getListOfRecipients(Recipients recipients)
        {
            List<User1> allreceivers=new List<User1>();
            if (!String.IsNullOrWhiteSpace(recipients.UserId))
            {
                // fetch user from database
            }
            else
            {
                // fetch list of users from database;
            }

            foreach (var receiver in allreceivers)
            {
                receiver.ChannelsInformation.Where(channel=> recipients.ChannelTypes.Contains(channel.ChannelType));
            }
            // for all receivers keep only the relevant channels in the list recipients channels.

            foreach (var guest in recipients.Guests)
            {
                var user = new User1();
                user.ChannelsInformation.Add(guest);
                allreceivers.Add(user);
            }
            return allreceivers;
        }

        private static ChannelEntity getChannel(Enums.ChannelType channelType,
            Enums.ChannelProvider channelProvider, string tenantId)
        {
            return null;
        }

        private static TemplateEntity getTemplate(Enums.ChannelType channelType)
        {
            if (channelType == Enums.ChannelType.Email)
                return emailTemplateEntity;
            return smsTemplateEntity;
        }

        private static Dictionary<string, string> getRequestConfig(SendMessageRequest request)
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

            if (request.htmlBody != null)
            {
                requestConfig.Add("htmlBody", request.htmlBody);
            }

            return requestConfig;
        }

        public static async Task SendMessages(SendMessageRequest request)
        {
            var recipients = getListOfRecipients(request.Recipients);

            foreach (var recipient in recipients)
            {
                foreach (var userChannelInformation in recipient.ChannelsInformation)
                {
                    var channel = getChannel(userChannelInformation.ChannelType,
                        userChannelInformation.ChannelProvider, request.TenantId);
                    TemplateEntity template = getTemplate(channel.ChannelType);

                    var channelConfig = channel.ChannelConfig;
                    var requestConfig = getRequestConfig(request);
                    var userConfig = recipient.Attributes;

                    userConfig.Add("userChannelId",userChannelInformation.UserChannelId);
                    configureTemplate(template, channelConfig, userConfig, requestConfig);
                    var status = await sendRequest(template);
                    Console.Out.WriteLine(status);
                }
            }
            
        }

        private static async Task<HttpStatusCode> sendRequest(TemplateEntity template)
        {
            var client = new RestClient(template.UrlEndpoint);
            var request = new RestRequest(template.UrlMethod);
            foreach (var header in template.Headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
            request.AddParameter("application/json", template.Body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.StatusCode;
        }

        private static void configureTemplate(TemplateEntity template, Dictionary<string, string> config, string prefix)
        {
            foreach (var pair in config)
            {
                string toReplace = $"${prefix}.{pair.Key}";
                template.Body = template.Body.Replace(toReplace, pair.Value);
                var keys = new List<string>(template.Headers.Keys);
                foreach (var key in keys)
                {
                    template.Headers.TryGetValue(key, out var value);
                    value = value.Replace(toReplace, pair.Value);
                    template.Headers[key] = value;
                }
            }
        }

        private static void configureTemplate(TemplateEntity template, Dictionary<string, string> channelConfig, Dictionary<string, string> userConfig, Dictionary<string, string> requestConfig)
        {

            configureTemplate(template, requestConfig, "req");
            configureTemplate(template, requestConfig, "req-user");
            configureTemplate(template, userConfig, "req-user");
            configureTemplate(template, userConfig, "user");
            configureTemplate(template, channelConfig, "config");
        }
    }
}