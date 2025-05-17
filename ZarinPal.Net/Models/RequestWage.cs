namespace ZarinPal.Net;

public class RequestWage
{
    public string Iban { get; set; } = default!;
    public int Amount { get; set; }
    public string Description { get; set; } = default!;
}
