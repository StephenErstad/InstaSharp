namespace InstaSharp.Models
{
    /// <summary>
    /// Represents a model that deserialized from the raw JSON in the Json property
    /// </summary>
    public abstract class JsonObject
    {
        /// <summary>
        /// Raw JSON this model was deserialize from
        /// </summary>
        public string Json { get; set; }
    }
}