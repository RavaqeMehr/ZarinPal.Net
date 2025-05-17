namespace ZarinPal.Net;

public class VerifyRequest(int amount, string authority)
{
    public string MerchantId { get; set; } = default!;
    public int Amount { get; set; } = amount;
    public string Authority { get; set; } = authority;

    public void Populate(ZarinPalClient zarinPal)
    {
        MerchantId = zarinPal.merchantId;
    }
}
