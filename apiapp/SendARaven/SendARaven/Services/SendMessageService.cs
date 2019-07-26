using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SendARaven.Models;
using RestSharp;
using RestSharp.Extensions;
using SendARaven.Controllers.service;

namespace SendARaven.Services
{
    public class SendMessageService
    {
        private string tenantId;
        private DBCoreService dbCoreService=new DBCoreService();

        public SendMessageService(string tenantId)
        {
            this.tenantId = tenantId;
        }

        private TemplateEntity GetSmsTemplateEntity()
        {
            return new TemplateEntity()
            {
                TemplateId = "smsTemplate1",
                Body =
                    "{\r\n  \"sender\": \"$config.senderId\",\r\n  \"route\": \"4\",\r\n  \"country\": \"91\",\r\n  \"sms\": [\r\n    {\r\n      \"message\": \"$req.textBody\",\r\n      \"to\": [\r\n        \"$req-user.userChannelId\"\r\n      ]\r\n    }\r\n  ]\r\n}",
                ChannelProvider = Enums.ChannelProvider.Msg91,
                ChannelType = Enums.ChannelType.Sms,
                Headers = new Dictionary<string, string>
                {
                    {"authkey", "$config.apiKey"},
                    {"content-type", "application/json"}
                },
                MandatoryConfigKeys = new List<string> {"apiKey", "senderId"},
                Status = 1,
                UrlEndpoint = "https://api.msg91.com/api/v2/sendsms?country=91",
                UrlMethod = Method.POST
            };

        }

        private TemplateEntity GetEmailTemplateEntity()
        {
            return new TemplateEntity()
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

        }

        private List<UserEntity> getListOfRecipients(Recipients recipients)
        {
            List<UserEntity> allreceivers=new List<UserEntity>();
            if (!String.IsNullOrWhiteSpace(recipients.UserId))
            {
                allreceivers.Add(dbCoreService.GetUserEntity(recipients.UserId, tenantId));
            }
            else
            {
                allreceivers.AddRange(dbCoreService.GetUsersByAttributes(recipients.Attributes, tenantId));
                // fetch list of all users from database based on the attribute given;
            }

            foreach (var receiver in allreceivers)
            {
                receiver.ChannelsInformation = dbCoreService.GetUserChannelInformation(receiver.UserId, tenantId);
                receiver.ChannelsInformation= receiver.ChannelsInformation.Where(channel=> recipients.ChannelTypes.Contains(channel.ChannelType)).ToList();
            }
            // for all receivers keep only the relevant channels in the list recipients channels.

            foreach (var guest in recipients.Guests)
            {
                var user = new UserEntity();
                user.ChannelsInformation.Add(guest);
                allreceivers.Add(user);
            }
            return allreceivers;
        }

        private ChannelEntity getActiveChannelByType(Enums.ChannelType channelType)
        {
            // from the database get a list of all channels for tenant for which status is active that is 1.
            // There maybe multiple. return any 1 of them.
            var channels= dbCoreService.GetActiveChannelsByType(channelType, tenantId);
            return channels.Count != 0 ? channels[0] : null;
        }

        private TemplateEntity getTemplate(Enums.ChannelType channelType)
        {
            if (channelType == Enums.ChannelType.Email)
                return GetEmailTemplateEntity();
            return GetSmsTemplateEntity();
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

            //if (request.htmlBody != null)
            //{
            //    requestConfig.Add("htmlBody", request.htmlBody);
            //}

            return requestConfig;
        }

        public async Task SendMessages(SendMessageRequest request)
        {
            var recipients = getListOfRecipients(request.Recipients);

            foreach (var recipient in recipients)
            {
                foreach (var userChannelInformation in recipient.ChannelsInformation)
                {
                    var channel = getActiveChannelByType(userChannelInformation.ChannelType);
                    // here ideally we should fetch template by template id and not 
                    TemplateEntity template = getTemplate(channel.ChannelType);

                    var channelConfig = channel.ChannelConfig;
                    var requestConfig = getRequestConfig(request);
                    var userConfig = new Dictionary<string, string>(recipient.Attributes); // This will be null for guests

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