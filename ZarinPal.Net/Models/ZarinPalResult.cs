using System.Text.Json;

namespace ZarinPal.Net;

public class ZarinPalResult<T>
{
    public T? Data { get; set; }

    public JsonElement? Errors { get; set; }
}
