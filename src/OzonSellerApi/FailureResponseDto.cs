using System.Text.Json.Serialization;

namespace OzonSellerApi;
public record FailureResponseDto
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("details")]
    public List<Detail> Details { get; set; } = [];

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    public class Detail
    {
        [JsonPropertyName("typeUrl")]
        public string TypeUrl { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }
};