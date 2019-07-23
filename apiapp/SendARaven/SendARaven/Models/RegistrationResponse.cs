﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class RegistrationResponse
    {
        public String ApiKey { get; set; }
        public String TenantId { get; set; }
        public Dictionary<String, Object> MetaData { get; set; }

    }
}
