using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ZarinPal.Net;

public partial class ZarinPalClient
{
    internal readonly string merchantId;
    internal readonly bool sandBox;
    internal readonly string baseUrl;
    public string AppBaseUrl { get; set; }
    public string CallbackPath { get; set; }
    internal readonly string callbackUrl;

    private readonly HttpClient httpClient;

    public ZarinPalClient(
        string merchantId,
        string appBaseUrl,
        string callbackPath,
        bool sandBox = false
    )
    {
        baseUrl = $"https://{(sandBox ? "sandbox" : "payment")}.zarinpal.com/";
        httpClient = new()
        {
            BaseAddress = new Uri(baseUrl),
            DefaultRequestHeaders =
            {
                {
                    "User-Agent",
                    $"ZarinPal.Net/{Assembly.GetCallingAssembly().GetName().Version?.ToString(3)}"
                }
            }
        };
        this.merchantId = merchantId;
        AppBaseUrl = appBaseUrl;
        CallbackPath = callbackPath;
        callbackUrl = $"{appBaseUrl}/{callbackPath}".Replace("//", "/").Replace("//", "/");
        this.sandBox = sandBox;
    }

    internal async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
#if DEBUG
        var path = request.RequestUri!.ToString().Split("/").Last();
        Console.WriteLine($"{path}: ===============");
        Console.WriteLine(responseString);
        Console.WriteLine("========================");
#endif

        ZarinPalResult<T> result = DeserializeFromJson<ZarinPalResult<T>>(responseString)!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result.Errors.ToString());
        }

        return result.Data!;
    }

    internal static readonly JsonSerializerOptions jsonOption =
        new(JsonSerializerOptions.Default)
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            IgnoreReadOnlyFields = false,
            Encoder = JavaScriptEncoder.Create(
                [UnicodeRanges.BasicLatin, UnicodeRanges.GeneralPunctuation, UnicodeRanges.Arabic]
            ),
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) }
        };

    internal static string? SerializeToJson<T>(T? obj)
    {
        if (obj == null)
            return null;
        return JsonSerializer.Serialize(obj, jsonOption);
    }

    internal static T? DeserializeFromJson<T>(string? json)
    {
        if (json == null)
            return default;
        return JsonSerializer.Deserialize<T>(json, jsonOption);
    }
}
