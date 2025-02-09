namespace OzonSellerApi.Enums;

/// <summary>
/// Статусы метода доставки
/// </summary>
public class DeliveryMethodStatus
{
    public static DeliveryMethodStatus New { get; } = new DeliveryMethodStatus("NEW");
    public static DeliveryMethodStatus Edited { get; } = new DeliveryMethodStatus("EDITED");
    public static DeliveryMethodStatus Active { get; } = new DeliveryMethodStatus("ACTIVE");
    public static DeliveryMethodStatus Disabled { get; } = new DeliveryMethodStatus("DISABLED");
    public static DeliveryMethodStatus None { get; } = new DeliveryMethodStatus("");

    public string Value { get; }

    public DeliveryMethodStatus(string value)
    {
        Value = value;
    }

    public override string ToString() => Value;

    public static DeliveryMethodStatus FromString(string? value)
    {
        if (string.IsNullOrEmpty(value)) return None;

        switch (value)
        {
            case "NEW": return New;
            case "EDITED": return Edited;
            case "ACTIVE": return Active;
            case "DISABLED": return Disabled;
            default: return None;
        }
    }
}