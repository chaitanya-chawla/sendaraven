using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class UserEntity
    {
        public string UserId;
        public string TenantId;
        public Dictionary<string, string> Attributes;
    }
}