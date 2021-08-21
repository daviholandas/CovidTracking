using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BoxTI.Challenge.CovidTracking.WebApi.Configs
{
    public class JsonConvertStringToDateTime : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueJson = reader.GetString();
            var date = DateTime.Parse(valueJson);
            
            if (DateTime.TryParse(valueJson, out var newDate))
                return newDate;
            return default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value);
    }
}