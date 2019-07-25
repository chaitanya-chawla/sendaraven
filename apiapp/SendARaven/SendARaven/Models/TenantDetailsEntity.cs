using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("developer")]
    public class TenantDetailsEntity
    {
        public TenantDetailsEntity()
        {
        }

        public TenantDetailsEntity(string apiKey, string tenantId, string email, string companyName)
        {
            ApiKey = apiKey;
            TenantId = tenantId;
            Email = email;
            CompanyName = companyName;
        }

        [Required, StringLength(128), Display(Name = "apiKey"), Column("apiKey")]
        public String ApiKey { get; set; }

        [Key]
        [Required, Display(Name = "tenantId"), Column("tenantId")]
        public String TenantId { get; set; }

        [Required, StringLength(128), Display(Name = "email"), Column("email")]
        public String Email { get; set; }

        [Required, StringLength(128), Display(Name = "companyName"), Column("companyName")]
        public String CompanyName { get; set; }

    }
}
