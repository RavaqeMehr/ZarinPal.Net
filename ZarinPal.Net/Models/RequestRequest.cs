namespace ZarinPal.Net;

public class RequestRequest
{
    public string MerchantId { get; set; } = default!;
    public string CallbackUrl { get; set; } = default!;
    public int Amount { get; set; }
    public string Currency { get; set; } = "IRR";

    public string Description { get; set; } = "";
    public Dictionary<string, string> Metadata { get; set; } = default!;
    public Wage[]? Wages { get; set; }

    public RequestRequest(
        int amount,
        string description,
        string? mobile = null,
        string? email = null,
        string? orderId = null,
        string? onlyThisCardPan = null
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
        if (onlyThisCardPan is not null)
        {
            Metadata.Add("card_pan", onlyThisCardPan);
        }
    }

    public string ReferrerId { get; set; } = "81hJmr";

    public void Populate(ZarinPalClient zarinPal)
    {
        MerchantId = zarinPal.merchantId;
        CallbackUrl = zarinPal.callbackUrl;
    }
}
