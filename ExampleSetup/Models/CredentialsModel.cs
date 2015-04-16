using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExampleSetup.Models
{
    public class CredentialsModel
    {
        [Required]
        [Display(Name = "API Endpoint")]
        public string API { get; set; }
        [Required]
        [Display(Name = "Client ID")]
        public string ClientID { get; set; }
        [Required]
        [Display(Name = "Secret Key")]
        public String SecretKey { get; set; }
        [Required]
        [Display(Name = "Resource ID Endpoint")]
        public String ResourceID { get; set; }
        [Required]
        [Display(Name = "API Version")]
        public String Version { get; set; }
        [Required]
        [Display(Name = "Authentication Context Path")]
        public String Authority { get; set; }
    }
}