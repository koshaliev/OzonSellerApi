using System.Text.Json;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Utils;
/// <summary>
/// Конвертер для сериализации списка long в массив строк.
/// </summary>
public class LongToStringArrayJsonConverter : JsonConverter<List<long>>
{
    public override List<long> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new List<long>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.String && long.TryParse(reader.GetString(), out long value))
            {
                result.Add(value);
            }
            else if (reader.TokenType == JsonTokenType.EndArray)
            {
                break;
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, List<long> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var id in value)
        {
            writer.WriteStringValue(id.ToString());
        }
        writer.WriteEndArray();
    }
}