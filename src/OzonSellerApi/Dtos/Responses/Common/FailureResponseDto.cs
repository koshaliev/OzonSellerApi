using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Common;
public record FailureResponseDto
{
    /// <summary>
    /// Код ошибки.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Дополнительная информация об ошибке.
    /// </summary>
    [JsonPropertyName("details")]
    public List<Detail> Details { get; set; } = [];

    /// <summary>
    /// Описание ошибки.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    public class Detail
    {
        /// <summary>
        /// Тип протокола передачи данных.
        /// </summary>
        [JsonPropertyName("typeUrl")]
        public string TypeUrl { get; set; } = string.Empty;

        /// <summary>
        /// Значение ошибки.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }
};