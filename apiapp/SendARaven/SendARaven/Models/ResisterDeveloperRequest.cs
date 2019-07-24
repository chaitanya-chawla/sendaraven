using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ResisterDeveloperRequest : HeaderRequestBase
    {
        [Required]
        public String Email { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String CompanyName { get; set; }
    }
}