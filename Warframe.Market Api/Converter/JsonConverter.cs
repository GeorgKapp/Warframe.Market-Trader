using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Warframe.Market_Api.Converter
{
    internal static class JsonConverter
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new StringEnumConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public static T FromJson<T>(string json) 
            where T : new() 
            => JsonConvert.DeserializeObject<T>(json, settings);

        public static string ToJson<T>(this T self) 
            where T : new() 
            => JsonConvert.SerializeObject(self, settings);
    }
}
