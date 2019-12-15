using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AppXamarinCrud
{
        public partial class Bicycle
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("year")]
            public long Year { get; set; }
        }

        public partial class Bicycle
        {
            public static Bicycle[] FromJson(string json) => JsonConvert.DeserializeObject<Bicycle[]>(json, AppXamarinCrud.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Bicycle[] self) => JsonConvert.SerializeObject(self, AppXamarinCrud.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    
}
