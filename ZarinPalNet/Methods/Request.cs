using System.Net.Http.Json;

namespace ZarinPalNet;

public partial class ZarinPalClient
{
    public async Task<RequestResult> Request(RequestRequest parameters)
    {
        parameters.Populate(this);

        HttpRequestMessage requestMessage =
            new(HttpMethod.Post, "pg/v4/payment/request.json")
            {
                Content = JsonContent.Create(parameters, options: jsonOption)
            };

        return await SendRequest<RequestResult>(requestMessage);
    }
}
