using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Web;
using RestSharp;

namespace SendARaven.Models
{
    public class TemplateEntity
    {
        public string TemplateId;
        public Enums.ChannelType ChannelType;
        public Enums.ChannelProvider ChannelProvider;
        public Dictionary<string, string> Headers;
        public string Body;
        public string UrlEndpoint;
        public Method UrlMethod;
        public List<string> MandatoryConfigKeys;
        public int Status;
    }
}