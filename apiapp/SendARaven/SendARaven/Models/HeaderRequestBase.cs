using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class HeaderRequestBase
    {
        public String apiKey { get; set; }

        public String tenantId { get; set; }


    }
}