using System.Net.Http.Json;

namespace ZarinPalNet;

public partial class ZarinPalClient
{
    public async Task<VerifyResult> Verify(VerifyRequest parameters)
    {
        parameters.Populate(this);

        HttpRequestMessage requestMessage =
            new(HttpMethod.Post, "pg/v4/payment/verify.json")
            {
                Content = JsonContent.Create(parameters, options: jsonOption)
            };

        return await SendRequest<VerifyResult>(requestMessage);
    }
}
