﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <remarks>
        /// To help ensure that the application is secure, this secret key should never
        /// appear in client-side code.
        /// In other words, API calls made using this value should only be made using
        /// server-side code.
        /// </remarks>
        [Required]
        [Display(Name = "Secret Key")]
        public string SecretKey { get; set; }
        [Required]
        [Display(Name = "Resource ID Endpoint")]
        public string ResourceID { get; set; }
        [Required]
        [Display(Name = "Full CDN Path")]
        public string FullCDNPath { get; set; }
        [Required]
        [Display(Name = "Authentication Context Path")]
        public string Authority { get; set; }
    }
}