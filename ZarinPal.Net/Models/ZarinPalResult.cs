namespace ZarinPal.Net;

public class ZarinPalResult<T>
{
    public T? Data { get; set; }
    public ZarinPalError? Errors { get; set; }
}
