using InstaSharp.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Infrastructure
{
    public class MediaConverter : CustomCreationConverter<Media>
    {

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {

            var jObject = JObject.ReadFrom(reader);
            var media = jObject.ToObject<Media>();
            media.Json = jObject.ToString();

            return media;
        }

        public override Media Create(Type objectType)
        {
            return new Media();
        }
    }
}
