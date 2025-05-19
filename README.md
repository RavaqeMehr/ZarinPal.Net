# ZarinPalNet

## نصب

برای استفاده از `ZarinPalNet` در پروژه خود، بسته نیوگت را اضافه کنید:

```bash
dotnet add package ZarinPalNet
```

یا در کنسول مدیریت بسته نیوگت:

```bash
Install-Package ZarinPalNet
```

## مثال

```csharp
ZarinPalClient zarinPal = new("marchant-token", "https://your-site.com/","/callback");

var request = await zarinPal.Request(
    new RequestRequest(amount: 100000, description: "تست", mobile: "09123456789")
);

// redirect to payment page:
// zarinPal.GetPayUrl(result);

// after payment:
var verify = await zarinPal.Verify(
    new VerifyRequest(amount: 100000, authority: "callback Authority")
);
```

For complete usage check Sample project
