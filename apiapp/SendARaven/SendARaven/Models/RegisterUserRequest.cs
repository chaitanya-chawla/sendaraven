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

        [Required]
        public String firstName { get; set; }

        [Required(AllowEmptyStrings = true)]
        public String middleName { get; set; }

        [Required]
        public String lastName { get; set; }

        public String email { get; set; }

        public Dictionary<String, Object> mobile { get; set; }

        public Dictionary<String, String> attributes { get; set; }
    }
}