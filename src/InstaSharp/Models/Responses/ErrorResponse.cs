using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models
{
    /// <summary>
    /// Response representing an error from the service
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the error code returned from the server
        /// </summary>
        /// <value>
        /// Error code returned from the server
        /// </value>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// Gets or sets the type of error returned from the service
        /// </summary>
        /// <value>
        /// Type of error returned from the server
        /// </value>
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }
        /// <summary>
        /// Gets or sets the error message returned from the service
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
