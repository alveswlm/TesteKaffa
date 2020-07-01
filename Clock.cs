using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaffaTestApplication
{
    public class Clock
    {
        [JsonProperty("currentDateTime")]
        public string CurrentDateTime { get; set; }
    }
}