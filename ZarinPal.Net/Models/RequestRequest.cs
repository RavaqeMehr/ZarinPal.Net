using System.Text.Json.Serialization;

namespace ZarinPal.Net;

public class RequestRequest
{
    public string MerchantId { get; set; } = default!;
    public string CallbackUrl { get; set; } = default!;
    public int Amount { get; set; }
    public string Currency { get; set; } = "IRR";

    public string Description { get; set; } = "";
    public Dictionary<string, string> Metadata { get; set; } = default!;

    public RequestRequest(
        int amount,
        string description,
        string? mobile = null,
        string? email = null,
        string? orderId = null
    )
    {
        Amount = amount;
        Description = description;

        Metadata = [];
        if (mobile is not null)
        {
            Metadata.Add("mobile", mobile);
        }
        if (email is not null)
        {
            Metadata.Add("email", email);
        }
        if (orderId is not null)
        {
            Metadata.Add("order_id", orderId);
        }
    }

#pragma warning disable CS0414
    [JsonInclude]
    private readonly string ReferrerId = "81hJmr";
#pragma warning restore CS0414

    public void Populate(ZarinPalClient zarinPal)
    {
        MerchantId = zarinPal.merchentId;
        CallbackUrl = zarinPal.callbackUrl;
    }
}
