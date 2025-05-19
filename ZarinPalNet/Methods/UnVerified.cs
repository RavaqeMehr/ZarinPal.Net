using System.Net.Http.Json;

namespace ZarinPalNet;

public partial class ZarinPalClient
{
    public async Task<UnVerifiedResult> UnVerified()
    {
        HttpRequestMessage requestMessage =
            new(HttpMethod.Post, "pg/v4/payment/unVerified.json")
            {
                Content = JsonContent.Create(new { merchantId }, options: jsonOption)
            };

        return await SendRequest<UnVerifiedResult>(requestMessage);
    }
}
