namespace ZarinPalNet;

public class ReverseRequest(string authority)
{
    public string MerchantId { get; set; } = default!;
    public string Authority { get; set; } = authority;

    public void Populate(ZarinPalClient zarinPal)
    {
        MerchantId = zarinPal.merchantId;
    }
}
