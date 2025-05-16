namespace ZarinPal.Net;

public class RequestResult
{
    public int Code { get; set; }
    public string Message { get; set; } = default!;
    public string Authority { get; set; } = default!;
    public FeeType FeeType { get; set; }
    public int Fee { get; set; }
}

public enum FeeType
{
    Merchant,
    Payer
}
