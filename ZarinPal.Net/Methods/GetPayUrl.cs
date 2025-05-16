namespace ZarinPal.Net;

public partial class ZarinPalClient
{
    public string GetPayUrl(RequestResult result) => $"{baseUrl}pg/StartPay/{result.Authority}";
}
