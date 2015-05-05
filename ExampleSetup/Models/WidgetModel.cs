using System;
using System.Collections.Generic;
using System.Web;

namespace ExampleSetup.Models
{
    public class WidgetModel
    {
        public string Token { get; private set; }

        public string Version { get; private set; }

        public WidgetModel(string token, string version)
        {
            this.Version = version;
            this.Token = token;
        }
    }
}