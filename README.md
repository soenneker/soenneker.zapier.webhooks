[![](https://img.shields.io/nuget/v/soenneker.zapier.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zapier.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zapier.webhooks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zapier.webhooks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zapier.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zapier.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zapier.webhooks/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.zapier.webhooks/actions/workflows/codeql.yml)

# Soenneker.Zapier.Webhooks

Sends JSON payloads to Zapier webhook URLs and returns Zapier's response body.

## Install

```shell
dotnet add package Soenneker.Zapier.Webhooks
```

## Registration

```csharp
using Soenneker.Zapier.Webhooks.Registrars;

services.AddZapierWebhookUtilAsSingleton();
```

Scoped registration is also available:

```csharp
services.AddZapierWebhookUtilAsScoped();
```

Both registrations reuse the singleton HTTP client cache.

## Usage

Use the complete webhook URL supplied by Zapier:

```csharp
public sealed class LeadNotifier
{
    private readonly IZapierWebhookUtil _webhooks;

    public LeadNotifier(IZapierWebhookUtil webhooks)
    {
        _webhooks = webhooks;
    }

    public ValueTask<string> Notify(string webhookUrl, string email, CancellationToken cancellationToken)
    {
        return _webhooks.Trigger(webhookUrl, new
        {
            eventName = "lead.created",
            email,
            occurredAt = DateTimeOffset.UtcNow
        }, cancellationToken);
    }
}
```

The payload is serialized with `System.Net.Http.Json`. A non-success HTTP response throws `HttpRequestException`; a successful response is returned as a string. Cancellation can stop the pending HTTP operation but cannot undo a webhook Zapier has already accepted.

## API

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IZapierWebhookUtil.Trigger(webhookUrl, payload, cancellationToken)` | Sends a JSON payload to a Zapier webhook URL. | The response body returned by Zapier. |
| `ZapierWebhookUtilRegistrar.AddZapierWebhookUtilAsSingleton(services)` | Adds `IZapierWebhookUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `ZapierWebhookUtilRegistrar.AddZapierWebhookUtilAsScoped(services)` | Adds `IZapierWebhookUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |
