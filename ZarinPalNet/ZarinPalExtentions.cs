using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ZarinPalNet;

public static class ZarinPalExtentions
{
    public static ZarinPalClient AddZarinPal(
        this IServiceCollection services,
        string merchantId,
        string baseUrl,
        string? callbackPath = null
    )
    {
        if (callbackPath is null)
        {
            var salt = Guid.NewGuid().ToString().Replace("-", "");

            callbackPath = $"/integrations/zarinpal/{salt}";
        }

        ZarinPalClient zarinPal = new(merchantId, baseUrl, callbackPath);

        services.AddSingleton(zarinPal);

        return zarinPal;
    }

    public static void MapZarinPalCallback(
        this ZarinPalClient zarinPal,
        WebApplication app,
        Func<Callback, Task<IResult>> action
    )
    {
        app.MapGet(zarinPal.CallbackPath, ([AsParameters] Callback callback) => action(callback));
    }
}
