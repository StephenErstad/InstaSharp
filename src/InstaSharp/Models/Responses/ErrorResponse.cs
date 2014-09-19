using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models
{
    public class ErrorResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
