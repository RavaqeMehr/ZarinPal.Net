namespace ZarinPalNet;

public class Callback
{
    public string Authority { get; set; } = default!;
    public CallbackStatus Status { get; set; }
}

public enum CallbackStatus
{
    OK,
    NOK
}
