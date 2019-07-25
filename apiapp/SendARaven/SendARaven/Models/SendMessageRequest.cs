using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class SendMessageRequest
    {
        [Required]
        public String subject { get; set; }
        
        public String textBody { get; set; }
        
        public String htmlBody { get; set; }

        public Recipients recipients { get; set; }

        public string tenantId { get; set; }


    }

    
}