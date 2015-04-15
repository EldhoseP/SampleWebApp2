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
        [Display(Name = "Please enter the API endpoint provided from Direct ID")]
        public string API { get; set; }
        [Required]
        [Display(Name = "Please enter the Client ID provided from Direct ID")]
        public string ClientID { get; set; }
        [Required]
        [Display(Name = "Please enter the key provided from Direct ID")]
        public String SecretKey { get; set; }
        [Required]
        [Display(Name = "Please enter the Resource ID provided from Direct ID")]
        public String ResourceID { get; set; }
        [Required]
        [Display(Name = "Please enter the Version provided from Direct ID")]
        public String Version { get; set; }
        [Required]
        [Display(Name = "Please enter the Authority provided from Direct ID")]
        public String Authority { get; set; }
    }
}