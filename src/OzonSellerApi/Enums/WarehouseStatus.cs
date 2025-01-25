using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OzonSellerApi.Enums;
/// <summary>
/// Возможные статусы склада.
/// </summary>
public enum WarehouseStatus
{
    [JsonPropertyName("new")]
    New,
    [JsonPropertyName("created")]
    Created,
    [JsonPropertyName("disabled")]
    Disabled,
    [JsonPropertyName("blocked")]
    Blocked,
    [JsonPropertyName("disabled_due_to_limit")]
    DisabledDueToLimit,
    [JsonPropertyName("error")]
    Error
}
