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
        private static List<User> getListOfRecipients(Recipients recipients)
        {
            List<User> allreceivers=new List<User>();
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
                var user = new User();
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

        private static TemplateEntity getTemplate(string templateId)
        {
            // return template
            
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
                    TemplateEntity template = getTemplate(channel.TemplateId);

                    var channelConfig = channel.ChannelConfig;
                    var requestConfig = getRequestConfig(request);
                    var userConfig = recipient.Attributes;

                    userConfig.Add("channelId",userChannelInformation.ChannelId);
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