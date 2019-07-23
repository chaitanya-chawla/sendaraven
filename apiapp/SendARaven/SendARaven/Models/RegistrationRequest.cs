using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class RegistrationRequest
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String CompanyName { get; set; }
    }
}