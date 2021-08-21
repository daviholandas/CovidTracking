using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BoxTI.Challenge.CovidTracking.WebApi.Configs
{
    public class JsonConvertStringToNumber : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (double.TryParse(value, out var newNUmber))
                return newNUmber;
            
            return default;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value);
    }
}