using System.Net.Http.Json;

namespace ZarinPalNet;

public partial class ZarinPalClient
{
    public async Task<ReverseResult> Reverse(ReverseRequest parameters)
    {
        parameters.Populate(this);

        HttpRequestMessage requestMessage =
            new(HttpMethod.Post, "pg/v4/payment/reverse.json")
            {
                Content = JsonContent.Create(parameters, options: jsonOption)
            };

        return await SendRequest<ReverseResult>(requestMessage);
    }
}
