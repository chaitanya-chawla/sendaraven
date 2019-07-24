using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    public class SendMessageRequest
    {
        public String subject { get; set; }
        
        public String textBody { get; set; }
        
        public String htmlBody { get; set; }

        public Recipients Recipients;

        public string TenantId;


    }

    
}