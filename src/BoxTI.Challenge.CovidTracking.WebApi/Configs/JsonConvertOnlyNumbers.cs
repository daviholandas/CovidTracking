using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BoxTI.Challenge.CovidTracking.WebApi.Configs
{
    public class JsonConvertOnlyNumbers : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonString = reader.GetString();
            if (string.IsNullOrEmpty(jsonString))
                return default;
            
            var stringValue = jsonString.Substring(1,jsonString.Length-1);
            
            if (double.TryParse(stringValue, out var newDouble))
                return newDouble;
            
            return default;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value);
    }
}