using OzonSellerApi.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Utils;
public class DeliveryMethodStatusJsonConverter : JsonConverter<DeliveryMethodStatus>
{
    public override DeliveryMethodStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return DeliveryMethodStatus.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, DeliveryMethodStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}