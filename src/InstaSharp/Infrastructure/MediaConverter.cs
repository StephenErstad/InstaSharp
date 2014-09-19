using System;
using InstaSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace InstaSharp.Infrastructure
{
    /// <summary>
    ///     Custom converter for Media objects to populate the raw JSON on the object
    /// </summary>
    public class MediaConverter : CustomCreationConverter<Media>
    {
        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JToken jObject = JToken.ReadFrom(reader);
            var media = jObject.ToObject<Media>();
            media.Json = jObject.ToString();

            return media;
        }

        /// <summary>
        /// Creates the new Media object
        /// </summary>
        /// <param name="objectType">Object type being requested</param>
        /// <returns>New Media object</returns>
        public override Media Create(Type objectType)
        {
            return new Media();
        }
    }
}