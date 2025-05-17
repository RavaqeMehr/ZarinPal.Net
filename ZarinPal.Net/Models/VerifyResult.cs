namespace ZarinPal.Net;

public class VerifyResult
{
    public int Code { get; set; }
    public string Message { get; set; } = default!;
    public string CardHash { get; set; } = default!;
    public string CardPan { get; set; } = default!;
    public int RefId { get; set; }
    public FeeType FeeType { get; set; }
    public int Fee { get; set; }
}
