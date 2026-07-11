[![](https://img.shields.io/nuget/v/soenneker.zapier.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zapier.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zapier.webhooks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zapier.webhooks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zapier.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zapier.webhooks/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Zapier.Webhooks
### A utility library for Zapier webhook calling

## Installation

```shell
dotnet add package Soenneker.Zapier.Webhooks
```

## Registration

```csharp
services.AddZapierWebhookUtilAsSingleton();
```

The scoped registration is also available through `AddZapierWebhookUtilAsScoped()`.

## Usage

```csharp
string response = await webhookUtil.Trigger(
    "https://hooks.zapier.com/hooks/catch/123456/abcdef/",
    new
    {
        OrderId = "12345",
        CustomerName = "Ada Lovelace"
    });
```

`Trigger` serializes the supplied payload as JSON and posts it to the complete webhook URL provided by Zapier. The returned string is Zapier's response body. Invalid URLs throw an `ArgumentException`, and non-success HTTP responses throw an `HttpRequestException`.
