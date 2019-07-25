using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserRequest : HeaderRequestBase
    {
        [Required]
        public String userId { get; set; }
        
        public Dictionary<String, String> attributes { get; set; }
    }
}