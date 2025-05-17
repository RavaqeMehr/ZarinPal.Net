using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ZarinPal.Net;

var builder = WebApplication.CreateBuilder(args);

var appBaseUrl = "https://localhost:3003/";

var zarinpal = builder.Services.AddZarinPal("merchantId", appBaseUrl);

var app = builder.Build();

var testAmount = 100000;

app.MapGet(
    "/",
    async () =>
    {
        var request = await zarinpal.Request(
            new RequestRequest(amount: testAmount, description: "تست", mobile: "09123456789")
        );

        return Results.Redirect(zarinpal.GetPayUrl(request));
    }
);

zarinpal.MapZarinPalCallback(
    app,
    async (callback) =>
    {
        if (callback.Status == CallbackStatus.OK)
        {
            var verify = await zarinpal.Verify(new VerifyRequest(testAmount, callback.Authority));
            if (verify.GetStatus() == VerifyStatus.NotVerified)
            {
                return Results.BadRequest("پرداخت انجام نشد!");
            }
            return Results.Accepted("پرداخت با موفقیت انجام شد.");
        }
        else
        {
            return Results.BadRequest("پرداخت انجام نشد!");
        }
    }
);

app.Run(appBaseUrl);
