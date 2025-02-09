using System.Text.Json;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Utils;
/// <summary>
/// Конвертер для сериализации строки в decimal.
/// </summary>
public class StringToDecimalJsonConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();
        return decimal.TryParse(value, out decimal result)
            ? result
            : throw new JsonException($"Невозможно конвертировать в decimal. Переданнное значение: {value}");
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
