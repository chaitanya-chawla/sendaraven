using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class RegisterUserRequest
    {
        public String userId { get; set; }
        public String firstName { get; set; }
        public String middleName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }

        public Dictionary<String, Object> mobile { get; set; }

        public Dictionary<String, Object> attributes { get; set; }
    }
}