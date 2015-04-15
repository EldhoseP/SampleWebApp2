using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSetup.Models
{
    public class WidgetModel
    {
        public String Token { get; set; }

        public String Version { get; set; }

        public WidgetModel(string token, string version)
        {
            this.Version = version;
            this.Token = token;
        }
    }
}