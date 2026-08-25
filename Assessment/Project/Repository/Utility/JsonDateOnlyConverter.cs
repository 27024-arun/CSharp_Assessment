using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToDoApplication.Repository.Utility
{
    internal class JsonDateOnlyConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? date = reader.GetString();
            if (date is null)
            {
                throw new JsonException("Date value is missing.");
            }

            return DateOnly.Parse(date);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
