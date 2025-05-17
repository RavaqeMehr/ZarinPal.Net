using System.Globalization;
using System.Text.Json.Serialization;

namespace ZarinPal.Net;

public class UnVerifiedResult
{
    public int Code { get; set; }
    public string Message { get; set; } = default!;
    public UnVerifiedResultItems[] Authorities { get; set; } = [];
}

public class UnVerifiedResultItems
{
    public string Authority { get; set; } = default!;
    public int Amount { get; set; }
    public string CallbackUrl { get; set; } = default!;
    public string Referer { get; set; } = default!;

    [JsonPropertyName("date")]
    public string DateString { get; set; } = default!;

    [JsonIgnore]
    public DateTime Date =>
        DateTime.ParseExact(DateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
}
