namespace ZarinPal.Net;

public class ZarinPalError
{
    public int Code { get; set; }
    public string Message { get; set; } = default!;
    public object[] Validations { get; set; } = [];
}
