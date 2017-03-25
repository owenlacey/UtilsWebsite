using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utils.Models.Shared
{
    public class ConfirmModal
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("yesButton")]
        public string YesButton { get; set; }
        [JsonProperty("confirmRoute")]
        public string ConfirmRoute { get; set; }
    }
}