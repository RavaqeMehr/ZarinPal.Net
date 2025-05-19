using System.Text.Json;

namespace ZarinPalNet;

public class ZarinPalResult<T>
{
    public T? Data { get; set; }

    public JsonElement? Errors { get; set; }
}
